using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduleServer.Models
{
    public class BusA1Data
    {
        public string PlateNumb { get; set; }
        public string OperatorID { get; set; }
        public string RouteUID { get; set; }
        public string RouteID { get; set; }
        public NameType RouteName { get; set; }
        public string Direction { get; set; }
        public PointType BusPosition { get; set; }
        public decimal Speed { get; set; }
        public decimal Azimuth { get; set; }
        public int MessageType { get; set; }
        public int DutyStatus { get; set; }
        public int BusStatus { get; set; }

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

        public class PointType
        {
            public decimal PositionLat { get; set; }
            public decimal PositionLon { get; set; }
        }
    }
}