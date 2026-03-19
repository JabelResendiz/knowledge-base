package com.devjra.tasks.mappers;

import com.devjra.tasks.domain.dto.TaskDto;
import com.devjra.tasks.domain.entities.Task;

public interface TaskMapper {
    Task fromDto(TaskDto taskDto);

    TaskDto toDto(Task task);
}