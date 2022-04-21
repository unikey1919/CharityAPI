using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CharityAPI.Models
{
    public class ApiResultMessage
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
        public string MessageDetail { get; set; }
        public string Data { get; set; }
    }

    [DataContract]
    public class ResultMessage
    {
        public ResultMessage()
        {
            IsError = false;
        }
        [DataMember]
        public bool IsError { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string MessageDetail { get; set; }
        [DataMember]
        public string Data { get; set; }
    }
}
