import inspect
import functools

class ContractError(Exception):
    """Excepción personalizada para violaciones de contrato."""
    pass

def validate_signature(invocable, func_name, is_postcondition=False):
    """Valida que la firma del objeto invocable sea compatible con la función decorada."""
    signature = inspect.signature(invocable)
    parameters = list(signature.parameters.values())

    if is_postcondition:
        # Para postcondiciones: debe tener exactamente un parámetro posicional,
        # y cualquier parámetro adicional debe tener valor por defecto
        if len(parameters) == 0:
            raise ContractError(f"La postcondición '{invocable.__name__}' debe tener al menos un parámetro.")
        
        # Contar parámetros posicionales sin valor por defecto
        positional_required = 0
        keyword_only_required = 0
        
        for param in parameters:
            if param.kind in (inspect.Parameter.POSITIONAL_ONLY, inspect.Parameter.POSITIONAL_OR_KEYWORD):
                if param.default is inspect.Parameter.empty:
                    positional_required += 1
            elif param.kind == inspect.Parameter.KEYWORD_ONLY:
                if param.default is inspect.Parameter.empty:
                    keyword_only_required += 1
        
        # Solo debe haber exactamente un parámetro posicional requerido
        # y ningún parámetro keyword-only requerido
        if positional_required != 1 or keyword_only_required > 0:
            raise ContractError(f"La postcondición '{invocable.__name__}' no tiene una firma válida. "
                              f"Debe tener exactamente un parámetro posicional requerido y ningún "
                              f"parámetro keyword-only requerido.")
    else:
        # La precondición debe ser compatible con la función decorada
        func_signature = inspect.signature(func_name)
        func_parameters = list(func_signature.parameters.values())
        
        if len(parameters) != len(func_parameters):
            raise ContractError(f"La precondición '{invocable.__name__}' no tiene una firma compatible "
                              f"con la función '{func_name.__name__}'. Número de parámetros diferente.")
        
        # Verificar que cada parámetro sea compatible
        for i, (precond_param, func_param) in enumerate(zip(parameters, func_parameters)):
            if (precond_param.name != func_param.name or
                precond_param.kind != func_param.kind or
                precond_param.default != func_param.default):
                raise ContractError(f"La precondición '{invocable.__name__}' no tiene una firma compatible "
                                  f"con la función '{func_name.__name__}'. Parámetro '{precond_param.name}' "
                                  f"no coincide con '{func_param.name}'.")

def contract(require=None, ensure=None):
    """Decorador para aplicar contratos de precondición y postcondición."""
    def decorator(func):
        if require:
            validate_signature(require, func)
        if ensure:
            validate_signature(ensure, func, is_postcondition=True)

        @functools.wraps(func)
        def wrapper(*args, **kwargs):
            if require and not require(*args, **kwargs):
                raise ContractError(f"Violación de precondición en '{func.__name__}'.")

            result = func(*args, **kwargs)

            if ensure and not ensure(result):
                raise ContractError(f"Violación de postcondición en '{func.__name__}'.")

            return result

        return wrapper
    return decorator