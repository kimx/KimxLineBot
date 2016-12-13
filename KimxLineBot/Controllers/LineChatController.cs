using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace KimxLineBot.Controllers
{
    /// <summary>
    /// http://studyhost.blogspot.tw/2016/12/linebot4-aspnetlinewebhook.html
    /// </summary>
    public class LineChatController : ApiController
    {
        [System.Web.Http.HttpPost]
        public IHttpActionResult POST()
        {
            string ChannelAccessToken = "";

            try
            {
                //取得 http Post RawData(should be JSON)
                string postData = Request.Content.ReadAsStringAsync().Result;
                //剖析JSON
                var ReceivedMessage = isRock.LineBot.Utility.Parsing(postData);
                //回覆訊息
                string Message;
                Message = "你說了:" + ReceivedMessage.events[0].message.text;
                //回覆用戶
                isRock.LineBot.Utility.ReplyMessage(ReceivedMessage.events[0].replyToken, Message, ChannelAccessToken);
                //回覆API OK
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok();
            }
        }
    }
}