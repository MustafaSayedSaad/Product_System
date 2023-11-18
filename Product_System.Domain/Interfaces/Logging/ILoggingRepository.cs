﻿namespace Product_System.Domain.Interfaces.Logging;

public interface ILoggingRepository
{
    Task<bool> LogExceptionInDb(Exception exception, string objJson = null!, LogType logType = LogType.Bug);
}
