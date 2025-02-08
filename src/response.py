
class HTTPResponse:
    def __init__(self, version, code, reason, headers, body):
        self.version = version
        self.code = int(code)
        self.reason = reason
        self.headers = headers
        self.body = body

    def get_body_raw(self):
        return self.body

    def get_headers(self):
        return self.headers

    def __str__(self):
        return f"<{self.__class__.__name__} [{self.code}]>"
