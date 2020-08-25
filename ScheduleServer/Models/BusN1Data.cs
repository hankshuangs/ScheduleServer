using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduleServer.Models
{
    class Root
    {
        public List<Dictionary<string, object>> N1Datas { get; set; }
    }
    public class BusN1DataList
    {
        public string UpdateTime { get; set; } //(DateTime) : [平臺] 資料更新日期時間(ISO8601格式:yyyy-MM-ddTHH:mm:sszzz) ,
        public int UpdateInterval { get; set; } //(integer) : [平臺] 資料更新週期(秒) ,
        public string SrcUpdateTime { get; set; } //(DateTime) : [來源端平臺] 資料更新時間(ISO8601格式:yyyy-MM-ddTHH:mm:sszzz) ,
        public int SrcUpdateInterval { get; set; } //(integer) : 來源端平台資料更新週期(秒)['-1: 不定期更新'] ,
        public string AuthorityCode { get; set; } //(string) : 業管機關簡碼 ,
        //public int VersionID { get; set; } //(integer, optional) : 資料版本編號 ,
        //public int Count { get; set; } //(integer, optional) : 資料總筆數 ,

        //public N1Data2[] N1Datas { get; set; } //(Array[N1Data]) : 資料(陣列)
        public List<BusN1Data> N1Datas { get; set; } //(Array[N1Data]) : 資料(陣列)
    }


    public class BusN1Data
    {
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
        //public int EstimateTime { get; set; } //(integer, optional): 到站時間預估(秒) [當StopStatus値為1~4或PlateNumb値為-1時，EstimateTime値為空値; 反之，EstimateTime有値] ,
        public string ScheduledTime { get; set; } //(string, optional): 預排班表時間 ,
        public bool IsLastBus { get; set; } //(boolean, optional): 是否為末班車 ,
        public string CurrentStop { get; set; } //(string, optional): 車輛目前所在站牌代碼 ,
        public int StopStatus { get; set; } //(integer, optional): 車輛狀態備註 : [0:'正常',1:'尚未發車',2:'交管不停靠',3:'末班車已過',4:'今日未營運'] ,
        public int StopCountDown { get; set; } //(integer, optional): 路線經過站牌之順序 ,
        public string DataTime { get; set; } //(DateTime, optional): 系統演算該筆預估到站資料的時間(ISO8601格式:yyyy-MM-ddTHH:mm:sszzz) ,
        public string RecTime { get; set; } //(DateTime): 來源端平台接收時間(ISO8601格式:yyyy-MM-ddTHH:mm:sszzz) ,
        public string TransTime { get; set; } //(DateTime): 來源端平台資料傳出時間(ISO8601格式:yyyy-MM-ddTHH:mm:sszzz)
    }
    public class NameType
    {
        public string Zh_tw { get; set; } //(string, optional): 中文繁體名稱 ,
        public string En { get; set; } //(string, optional): 英文名稱
    }
}