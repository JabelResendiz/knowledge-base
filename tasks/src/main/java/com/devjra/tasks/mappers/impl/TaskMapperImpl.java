package com.devjra.tasks.mappers.impl;

import org.springframework.stereotype.Component;

import com.devjra.tasks.domain.dto.TaskDto;
import com.devjra.tasks.domain.entities.Task;
import com.devjra.tasks.mappers.TaskMapper;

@Component
public class TaskMapperImpl implements TaskMapper {

    @Override
    public Task fromDto(TaskDto taskDto) {
        return new Task(
            taskDto.id(),
            taskDto.title(),
            taskDto.description(),
            taskDto.dueDate(),
            taskDto.status(),
            taskDto.priority(),
            null, null, null
        );
    }

    @Override
    public TaskDto toDto(Task task)
    {
        return new TaskDto(
            task.getId(),
            task.getTitle(),
            task.getDescription(),
            task.getDueDate(),
            task.getStatus(),
            task.getPriority()
        );
    }


}