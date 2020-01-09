using GoogleCaptchaDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

namespace GoogleCaptchaDemo.Helpers
{
    public class GoogleCaptchaHelper
    {
        public static bool ValdiateCaptcha(string encodedResponse)
        {
            if (String.IsNullOrEmpty(encodedResponse))
                return false;


            var googleRecaptchaUrl = ConfigurationManager.AppSettings["GoogleRecaptchaUrl"];
            var googleRecaptchaSecret = ConfigurationManager.AppSettings["GoogleRecaptchaSecret"];
            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format(googleRecaptchaUrl, googleRecaptchaSecret, encodedResponse));

            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponseModel>(reply);

            if (!captchaResponse.Success)
            {
                return false;
            }

            return true;
        }
    }
}