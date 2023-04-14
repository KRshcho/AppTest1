using System;
using System.Collections.Generic;
using System.Text;

namespace AppTest1.APIModel.Response
{
    public class ResPostOffice : ResultModel
    {
        /// <summary>
        /// 우편번호 조회 결과 코드
        /// </summary>
        public string errorCode { get; set; }

        /// <summary>
        /// 우편번호 조화 결과 메세지
        /// </summary>
        public string message { get; set; }
    }
}
