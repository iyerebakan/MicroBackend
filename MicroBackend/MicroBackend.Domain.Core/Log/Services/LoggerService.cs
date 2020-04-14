using MicroBackend.Domain.Core.Log.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Domain.Core.Log.Services
{
    public static class LoggerService
    {
        public static void InfoAsync(ILog logger)
        {
            logger.Info();
        }
        public static void ErrorAsync(ILog logger)
        {
            logger.Error();
        }
        public static void WarnAsync(ILog logger)
        {
            logger.Warn();
        }
             
    }
}
