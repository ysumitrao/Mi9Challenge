using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace Mi9ChallengeApp
{
    public class Mi9ChallengeController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage PostData([FromBody] RequestBody requestBody)
        {
            try
            {
                if (requestBody != null && requestBody.payload != null && requestBody.payload.Count > 0)
                {
                    ResponseBody responseBody = new ResponseBody();
                    List<Response> lstResponse = new List<Response>();
                    foreach(TVChannelDetails channelDetails in requestBody.payload)
                    {
                        if (channelDetails.drm == true && channelDetails.episodeCount > 0)
                        {
                            Response responseObj = new Response();
                            responseObj.image = channelDetails.image.showImage;
                            responseObj.slug = channelDetails.slug;
                            responseObj.title = channelDetails.title;

                            lstResponse.Add(responseObj);
                        }
                    }

                    responseBody.response = lstResponse;
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    return Request.CreateResponse(HttpStatusCode.OK, responseBody);
                }
                else
                {
                    var error = new System.Web.Http.HttpError { { "error", "Could not decode request: JSON parsing failed" } };
                    //var error = new HttpError("Could not decode request: JSON parsing failed");
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, error);
                }                
            }
            catch (Exception ex)
            {
                var error = new System.Web.Http.HttpError { { "error", "Could not decode request: JSON parsing failed" } };
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, error);
            }
        }
    }

    public class RequestBody
    {
        public List<TVChannelDetails> payload { get; set; }
        public string skip { get; set; }
        public string take { get; set; }
        public string totalRecords { get; set; }
    }

    public class TVChannelDetails
    {
        public string country { get; set; }
        public string description { get; set; }
        public bool drm { get; set; }
        public int episodeCount { get; set; }
        public string slug { get; set; }
        public string title { get; set; }
        public Image image { get; set; } 
    }

    public class Image
    {
        public string showImage { get; set; }
    }

    public class ResponseBody
    {
        public List<Response> response { get; set; }
        }

    public class Response
    {
        public string image { get; set; }
        public string slug { get; set; }
        public string title { get; set; }
    }
}