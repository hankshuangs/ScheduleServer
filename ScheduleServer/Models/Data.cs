using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScheduleServer.Models
{
    public class A1Data
    {
        [Key]
        public int Id { get; set; }
        public string PlateNumb { get; set; }
        public string RouteID { get; set; }
        public string Direction { get; set; }
        public string PositionLat { get; set; }
        public string PositionLon { get; set; }
        public string Speed { get; set; }
        public string Azimuth { get; set; }
        public string MessageType { get; set; }
        public string DutyStatus { get; set; }
        public string BusStatus { get; set; }
        public string GPSTime { get; set; }
        public string CreateTime { get; set; }
    }

    public class A2Data
    {
        [Key]
        public int Id { get; set; }
        public string PlateNumb { get; set; }
        public string RouteID { get; set; }
        public string Direction { get; set; }
        public string StopID { get; set; }
        public string StopName { get; set; }
        public string DutyStatus { get; set; }
        public string BusStatus { get; set; }
        public string MessageType { get; set; }
        public string StopSequence { get; set; }
        public string A2EventType { get; set; }
        public string GPSTime { get; set; }
        public string CreateTime { get; set; }
    }

    public class N1Data
    {
        [Key]
        public int Id { get; set; }
        public string RouteUID { get; set; } //(string, optional): 路線唯一識別代碼，規則為 {業管機關代碼} + {RouteID}，其中 {業管機關代碼} 可於Authority API中的AuthorityCode欄位查詢 ,
        public string RouteID { get; set; } //(string): 地區既用中之路線代碼(為原資料內碼) ,
        public NameType RouteName { get; set; } //(NameType, optional): 路線名稱 ,
        public string SubRouteUID { get; set; } //(string, optional): 附屬路線唯一識別代碼，規則為 {業管機關簡碼} + {SubRouteID}，其中 {業管機關簡碼} 可於Authority API中的AuthorityCode欄位查詢 ,
        public string SubRouteID { get; set; } //(string, optional): 地區既用中之附屬路線代碼(為原資料內碼) ,
        public NameType SubRouteName { get; set; } //(NameType, optional): 附屬路線名稱 ,
        public int Direction { get; set; } //(integer): 車輛去返程(該方向指的是此公車運具目前所在路線的去返程方向，非指站牌所在路線的去返程方向，使用時請加值業者多加注意) : [0:'去程',1:'返程',2:'迴圈',255:'未知'] ,
        public string DestinationStopID { get; set; } //(string, optional): 迄點站站牌ID代碼 ,
        public NameType DestinationStopName { get; set; } //(NameType, optional): 迄點站站牌名稱 ,
        public string StopUID { get; set; } //(string, optional): 站牌唯一識別代碼，規則為 {業管機關簡碼} + {StopID}，其中 {業管機關簡碼} 可於Authority API中的AuthorityCode欄位查詢 ,
        public string StopID { get; set; } //(string): 地區既用中之站牌代碼(為原資料內碼) ,
        public NameType StopName { get; set; } //(NameType, optional): 站牌名稱 ,
        public string PlateNumb { get; set; } //(string, optional): 車牌號碼 [値為値為-1時，表示目前該站牌無車輛行駛] ,
        public int EstimateTime { get; set; } //(integer, optional): 到站時間預估(秒) [當StopStatus値為1~4或PlateNumb値為-1時，EstimateTime値為空値; 反之，EstimateTime有値] ,
        public string ScheduledTime { get; set; } //(string, optional): 預排班表時間 ,
        public bool IsLastBus { get; set; } //(boolean, optional): 是否為末班車 ,
        public string CurrentStop { get; set; } //(string, optional): 車輛目前所在站牌代碼 ,
        public int StopStatus { get; set; } //(integer, optional): 車輛狀態備註 : [0:'正常',1:'尚未發車',2:'交管不停靠',3:'末班車已過',4:'今日未營運'] ,
        public int StopCountDown { get; set; } //(integer, optional): 路線經過站牌之順序 ,
        public DateTime DataTime { get; set; } //(DateTime, optional): 系統演算該筆預估到站資料的時間(ISO8601格式:yyyy-MM-ddTHH:mm:sszzz) ,
        public DateTime RecTime { get; set; } //(DateTime): 來源端平台接收時間(ISO8601格式:yyyy-MM-ddTHH:mm:sszzz) ,
        public DateTime TransTime { get; set; } //(DateTime): 來源端平台資料傳出時間(ISO8601格式:yyyy-MM-ddTHH:mm:sszzz)
    }
}