using System;
using System.Collections.Generic;
using System.Text;

namespace AppTest1.APIModel
{
    public class ResultModel
    {
        // <summary>
        /// 200-299 제외한 값을 사용한다. IsSuccessStatusCode 성공으로 인식
        /// 00 : 성공
        /// 10 : 이미 처리된 전표입니다.
        /// 11 : 조회 데이터가 없습니다.
        /// 90 : API 키 인증 실패
        /// 91 : 잘못된 데이터 요청,
        /// 92 : API 요청 권한 없음,
        /// 94 : 찾을 수 없는 데이터,
        /// 95 : 실행할 수 없는 조건 및 상태,
        /// 96 : 이미 실행된 상태,
        /// 99 : 시스템 예외 처리
        /// </summary>
        public string ResultCode { get; set; } = "00"; //기본값 "00", 특이사항 발생시 다른 코드 입력

        /// <summary>
        /// 결과 메시지 [빈값이면 성공, 실패면 오류 메시지]
        /// </summary>
        public string ResultMessage { get; set; } = string.Empty;
    }
}
