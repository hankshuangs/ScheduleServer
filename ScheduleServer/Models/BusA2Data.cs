using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduleServer.Models
{
    public class BusA2Data
    {
        public string PlateNumb { get; set; }
        public string OperatorID { get; set; }
        public string RouteUID { get; set; }
        public string RouteID { get; set; }
        public NameType RouteName { get; set; }
        public string Direction { get; set; }
        public string StopUID { get; set; }
        public string StopID { get; set; }

        public NameType StopName { get; set; }

        public int StopSequence { get; set; }
        public int MessageType { get; set; }
        public int DutyStatus { get; set; }
        public int BusStatus { get; set; }
        public int A2EventType { get; set; }

        public DateTime GPSTime { get; set; }

        public DateTime TransTime { get; set; }

        public DateTime SrcRecTime { get; set; }
        public DateTime SrcTransTime { get; set; }
        public DateTime SrcUpdateTime { get; set; }
        public DateTime UpdateTime { get; set; }


        /// <summary>
        /// 巴士路線名稱
        /// </summary>
        public class NameType
        {
            public string Zh_tw { get; set; }
            public string En { get; set; }
        }
    }
}