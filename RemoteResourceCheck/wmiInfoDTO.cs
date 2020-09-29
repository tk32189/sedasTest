using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteResourceCheck
{
    public class WmiInfoDTO
    {
        private decimal memUse; //메모리 사용중
        private decimal memNotUse; //메모리 미사용

        private string totalVisibleMemorySize; //전체 메모리
        private string freePhysicalMemory; //여유 메모리
        private string usingPhysicalMemory; //사용 메모리

        private string os;
        private string osVersion;
        private string buildNumber;
        private string serverName;

        private decimal cpuTime; //CPU 사용중
        private decimal cpuNotUseTime; //CPU 미사용

        public decimal MemUse
        {
            get
            {
                return memUse;
            }

            set
            {
                memUse = value;
            }
        }

        public decimal MemNotUse
        {
            get
            {
                return memNotUse;
            }

            set
            {
                memNotUse = value;
            }
        }

        public string TotalVisibleMemorySize
        {
            get
            {
                return totalVisibleMemorySize;
            }

            set
            {
                totalVisibleMemorySize = value;
            }
        }

        public string FreePhysicalMemory
        {
            get
            {
                return freePhysicalMemory;
            }

            set
            {
                freePhysicalMemory = value;
            }
        }

        public string UsingPhysicalMemory
        {
            get
            {
                return usingPhysicalMemory;
            }

            set
            {
                usingPhysicalMemory = value;
            }
        }

        public string Os
        {
            get
            {
                return os;
            }

            set
            {
                os = value;
            }
        }

        public string OsVersion
        {
            get
            {
                return osVersion;
            }

            set
            {
                osVersion = value;
            }
        }

        public string BuildNumber
        {
            get
            {
                return buildNumber;
            }

            set
            {
                buildNumber = value;
            }
        }

        public string ServerName
        {
            get
            {
                return serverName;
            }

            set
            {
                serverName = value;
            }
        }

        public decimal CpuTime
        {
            get
            {
                return cpuTime;
            }

            set
            {
                cpuTime = value;
            }
        }

        public decimal CpuNotUseTime
        {
            get
            {
                return cpuNotUseTime;
            }

            set
            {
                cpuNotUseTime = value;
            }
        }
    }
}
