using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;

namespace ScheduleServer.Models
{
    public class Obtain
    {

        string strconnection = ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
        int GetA1 = 0;
        int GetA2 = 0;


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="EncryptText"></param>
        /// <param name="EncryptKey"></param>
        /// <returns></returns>
        public static string HMACSHA1Text(string EncryptText, string EncryptKey)
        {
            HMACSHA1 hmacsha1 = new HMACSHA1();
            hmacsha1.Key = System.Text.Encoding.UTF8.GetBytes(EncryptKey);
            byte[] dataBuffer = System.Text.Encoding.UTF8.GetBytes(EncryptText);
            byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);
            return Convert.ToBase64String(hashBytes);

        }


        public void BusN1DataGet(string city, string routeName, string filter)
        {
            const string appID = "de9846031af54c0e95cd3f0c68e6c9e9";
            const string appKey = "VVnz4vQe5Lsu4qtmUJAr79uVLRQ";

            var client = new RestClient($"http://ptx.transportdata.tw/MOTC/v3/Bus/EstimatedTimeOfArrival/City/{city}/{routeName}?&$format=JSON");
            var request = new RestRequest(Method.GET);



            string gmtStr = DateTime.UtcNow.ToString("r");
            string signature = HMACSHA1Text(@"x-date: " + gmtStr, appKey);


            string Authorization = @"hmac  username=""" + appID + @""", algorithm=""hmac-sha1"", headers=""x-date"", signature=""" + signature + @"""";


            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", Authorization);
            request.AddHeader("x-date", gmtStr);
            request.AddHeader("Accept-Encoding", "gzip, deflate");


            IRestResponse response = client.Execute(request);

            string Result = "";
            if (response.StatusCode == HttpStatusCode.OK)
            {
                //var APIResult = JsonConvert.DeserializeObject<List<BusN1DataList>>(response.Content);
                //var APIResult = JsonConvert.DeserializeObject<BusN1Data>(response.Content).N1Datas;
                var APIResult = JsonConvert.DeserializeObject<Root>(response.Content).N1Datas;
                //if (APIResult != null && APIResult.Count > 0)
                //{
                //    string PlateNumb, RouteID, Direction;
                //    int DutyStatus, BusStatus, MessageType;
                //    DateTime GPSTime;
                //    decimal PositionLat, PositionLon, Speed, Azimuth;
                //    string CreateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                //    foreach (BusN1DataList PTXData in APIResult)
                //    {
                //        GetA1 = GetA1 + 1;

                //        //PlateNumb = PTXData.PlateNumb;
                //        //RouteID = PTXData.RouteID;
                //        //Direction = PTXData.Direction;
                //        //PositionLat = PTXData.BusPosition.PositionLat;
                //        //PositionLon = PTXData.BusPosition.PositionLon;
                //        //Speed = PTXData.Speed;
                //        //Azimuth = PTXData.Azimuth;
                //        //DutyStatus = PTXData.DutyStatus;
                //        //BusStatus = PTXData.BusStatus;
                //        //MessageType = PTXData.MessageType;
                //        //GPSTime = PTXData.GPSTime;

                //        //Result = Result +
                //        //                  "INSERT INTO A1Data(PlateNumb, RouteID, Direction,DutyStatus,BusStatus, MessageType,GPSTime,PositionLat, PositionLon, Speed, Azimuth, CreateTime)" +
                //        //                  "VALUES(" +
                //        //                  " '" + PlateNumb + "' " +
                //        //                  ",'" + RouteID + "' " +
                //        //                  ",'" + Direction + "' " +
                //        //                  ", " + DutyStatus + " " +
                //        //                  ", " + BusStatus + " " +
                //        //                  ", " + MessageType + " " +
                //        //                  ",'" + GPSTime.ToString("yyyy/MM/dd HH:mm:ss") + "' " +
                //        //                  ", " + PositionLat + "  " +
                //        //                  ", " + PositionLon + "  " +
                //        //                  ", " + Speed + "  " +
                //        //                  ", " + Azimuth + "  " +
                //        //                  ",'" + CreateTime + "' " +
                //        //                  ") ;";


                //    }

                //}
            }

            //寫入資料
            if (Result != "")
            {
                SqlConnection connnew = new SqlConnection(strconnection);

                try
                {
                    connnew.Open();
                    SqlCommand cmmdnew = new SqlCommand(Result, connnew);
                    cmmdnew.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("A1Data error ");
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connnew.Close();
                }
            }
        }
        /// <summary>
        /// 取得指定[縣市],[路線名稱]的公車動態定時資料(A1)[批次更新]
        /// </summary>
        /// <param name="city"></param>
        /// <param name="routeName"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public void BusA1DataGet(string city, string routeName, string filter)
        {
            //appID 與 appKey
            //L1
            const string appID = "de9846031af54c0e95cd3f0c68e6c9e9";
            const string appKey = "VVnz4vQe5Lsu4qtmUJAr79uVLRQ";
            //L2
            //const string appID = "9d23cca661e34c60a27da4102820cdca";
            //const string appKey = "szVA8s6nvxAqwzbZSQkiMVA2fyM";



            //Use RestSharp Call API
            var client = new RestClient($"http://ptx.transportdata.tw/MOTC/v2/Bus/RealTimeByFrequency/City/{city}/{routeName}?&$format=JSON");

            var request = new RestRequest(Method.GET);



            string gmtStr = DateTime.UtcNow.ToString("r");
            string signature = HMACSHA1Text(@"x-date: " + gmtStr, appKey);


            string Authorization = @"hmac  username=""" + appID + @""", algorithm=""hmac-sha1"", headers=""x-date"", signature=""" + signature + @"""";


            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", Authorization);
            request.AddHeader("x-date", gmtStr);
            request.AddHeader("Accept-Encoding", "gzip, deflate");


            IRestResponse response = client.Execute(request);

            string Result = "";

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var APIResult = JsonConvert.DeserializeObject<List<BusA1Data>>(response.Content);

                if (APIResult != null && APIResult.Count > 0)
                {
                    string PlateNumb, RouteID, Direction;
                    int DutyStatus, BusStatus, MessageType;
                    DateTime GPSTime;
                    decimal PositionLat, PositionLon, Speed, Azimuth;
                    string CreateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    foreach (BusA1Data PTXData in APIResult)
                    {
                        GetA1 = GetA1 + 1;

                        PlateNumb = PTXData.PlateNumb;
                        RouteID = PTXData.RouteID;
                        Direction = PTXData.Direction;
                        PositionLat = PTXData.BusPosition.PositionLat;
                        PositionLon = PTXData.BusPosition.PositionLon;
                        Speed = PTXData.Speed;
                        Azimuth = PTXData.Azimuth;
                        DutyStatus = PTXData.DutyStatus;
                        BusStatus = PTXData.BusStatus;
                        MessageType = PTXData.MessageType;
                        GPSTime = PTXData.GPSTime;

                        Result = Result +
                                          "INSERT INTO A1Data(PlateNumb, RouteID, Direction,DutyStatus,BusStatus, MessageType,GPSTime,PositionLat, PositionLon, Speed, Azimuth, CreateTime)" +
                                          "VALUES(" +
                                          " '" + PlateNumb + "' " +
                                          ",'" + RouteID + "' " +
                                          ",'" + Direction + "' " +
                                          ", " + DutyStatus + " " +
                                          ", " + BusStatus + " " +
                                          ", " + MessageType + " " +
                                          ",'" + GPSTime.ToString("yyyy/MM/dd HH:mm:ss") + "' " +
                                          ", " + PositionLat + "  " +
                                          ", " + PositionLon + "  " +
                                          ", " + Speed + "  " +
                                          ", " + Azimuth + "  " +
                                          ",'" + CreateTime + "' " +
                                          ") ;";


                    }

                }
            }

            //寫入資料
            if (Result != "")
            {
                SqlConnection connnew = new SqlConnection(strconnection);

                try
                {
                    connnew.Open();
                    SqlCommand cmmdnew = new SqlCommand(Result, connnew);
                    cmmdnew.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("A1Data error ");
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connnew.Close();
                }
            }


        }

        /// <summary>
        /// 取得指定[縣市],[路線名稱]的公車動態定點資料(A2)[批次更新]
        /// </summary>
        /// <param name="city">縣市</param>
        /// <param name="routeName">路線</param>
        /// <param name="top">筆數</param>
        /// <returns></returns>
        public void BusA2DataGet(string city, string routeName, string filter)
        {
            //appID 與 appKey
            //L1
            const string appID = "de9846031af54c0e95cd3f0c68e6c9e9";
            const string appKey = "VVnz4vQe5Lsu4qtmUJAr79uVLRQ";
            //L2
            //const string appID = "9d23cca661e34c60a27da4102820cdca";
            //const string appKey = "szVA8s6nvxAqwzbZSQkiMVA2fyM";



            //Use RestSharp Call API
            //var client = new RestClient($"http://ptx.transportdata.tw/MOTC/v2/Bus/RealTimeNearStop/City/{city}/{routeName}?%top={top}&$format=JSON");
            //client = new RestClient($"http://ptx.transportdata.tw/MOTC/v2/Bus/RealTimeNearStop/City/{city}/{routeName}?%filter={filter}&$format=JSON");
            var client = new RestClient($"http://ptx.transportdata.tw/MOTC/v2/Bus/RealTimeNearStop/City/{city}/{routeName}?$format=JSON");


            var request = new RestRequest(Method.GET);



            string gmtStr = DateTime.UtcNow.ToString("r");
            string signature = HMACSHA1Text(@"x-date: " + gmtStr, appKey);


            string Authorization = @"hmac  username=""" + appID + @""", algorithm=""hmac-sha1"", headers=""x-date"", signature=""" + signature + @"""";


            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", Authorization);
            request.AddHeader("x-date", gmtStr);
            request.AddHeader("Accept-Encoding", "gzip, deflate");


            IRestResponse response = client.Execute(request);

            string Result = "";

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var APIResult = JsonConvert.DeserializeObject<List<BusA2Data>>(response.Content);

                if (APIResult != null && APIResult.Count > 0)
                {

                    string PlateNumb, RouteID, Direction, StopID, StopName;
                    int DutyStatus, BusStatus, MessageType, StopSequence, A2EventType;
                    DateTime GPSTime;
                    string CreateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    foreach (BusA2Data PTXData in APIResult)
                    {
                        GetA2 = GetA2 + 1;

                        PlateNumb = PTXData.PlateNumb;
                        RouteID = PTXData.RouteID;
                        Direction = PTXData.Direction;
                        StopID = PTXData.StopID;
                        StopName = PTXData.StopName.Zh_tw;
                        StopSequence = PTXData.StopSequence;
                        A2EventType = PTXData.A2EventType;

                        DutyStatus = PTXData.DutyStatus;
                        BusStatus = PTXData.BusStatus;
                        MessageType = PTXData.MessageType;
                        GPSTime = PTXData.GPSTime;

                        Result = Result + "IF NOT EXISTS(SELECT PlateNumb FROM A2Data WHERE PlateNumb='" + PlateNumb + "' AND A2EventType=" + A2EventType +
                                                       " AND GPSTime='" + GPSTime.ToString("yyyy/MM/dd HH:mm:ss") + "')" +
                                          "BEGIN " +
                                          "INSERT INTO A2Data(PlateNumb, RouteID, Direction, StopID, StopName,DutyStatus, BusStatus, MessageType, StopSequence, A2EventType,GPSTime, CreateTime)" +
                                          "VALUES(" +
                                          " '" + PlateNumb + "' " +
                                          ",'" + RouteID + "' " +
                                          ",'" + Direction + "' " +
                                          ",'" + StopID + "' " +
                                          ",'" + StopName + "' " +
                                          ", " + DutyStatus + " " +
                                          ", " + BusStatus + " " +
                                          ", " + MessageType + " " +
                                          ", " + StopSequence + " " +
                                          ", " + A2EventType + " " +
                                          ",'" + GPSTime.ToString("yyyy/MM/dd HH:mm:ss") + "' " +
                                          ",'" + CreateTime + "' " +
                                          ") END ;";

                    }
                }
            }


            //寫入資料          
            if (Result != "")
            {
                SqlConnection connnew = new SqlConnection(strconnection);

                try
                {
                    connnew.Open();
                    SqlCommand cmmdnew = new SqlCommand(Result, connnew);
                    cmmdnew.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("A2Data error ");
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connnew.Close();
                }
            }

        }

    }
}