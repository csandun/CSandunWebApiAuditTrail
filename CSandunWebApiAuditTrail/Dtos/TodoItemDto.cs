﻿namespace CSandunWebApiAuditTrail.Dtos;

public class TodoItemDto
{
    public long? Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
    public bool IsDelete { get; set; }
}