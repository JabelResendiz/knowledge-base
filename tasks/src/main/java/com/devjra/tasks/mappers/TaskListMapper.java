package com.devjra.tasks.mappers;

import com.devjra.tasks.domain.dto.TaskListDto;
import com.devjra.tasks.domain.entities.TaskList;

public interface TaskListMapper {
    TaskList fromDto(TaskListDto taskListDto);

    TaskListDto toDto(TaskList taskList);
}