package com.devjra.tasks.domain.dto;

import java.time.LocalDateTime;
import java.util.UUID;

import com.devjra.tasks.domain.entities.TaskPriority;
import com.devjra.tasks.domain.entities.TaskStatus;


public record TaskDto(
        UUID id,
        String title,
        String description,
        LocalDateTime dueDate,
        TaskStatus status,
        TaskPriority priority
) {

}