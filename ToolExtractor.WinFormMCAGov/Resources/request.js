fetch("https://www.mca.gov.in/mcafoportal/vpdCheckCompanyStatus.do", {
    "headers": {
        "accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7",
        "accept-language": "en-US,en;q=0.9",
        "cache-control": "max-age=0",
        "content-type": "application/x-www-form-urlencoded",
        "sec-ch-ua": "\"Microsoft Edge\";v=\"111\", \"Not(A:Brand\";v=\"8\", \"Chromium\";v=\"111\"",
        "sec-ch-ua-mobile": "?0",
        "sec-ch-ua-platform": "\"Windows\"",
        "sec-fetch-dest": "document",
        "sec-fetch-mode": "navigate",
        "sec-fetch-site": "same-origin",
        "sec-fetch-user": "?1",
        "upgrade-insecure-requests": "1",

        "cookie": "HttpOnly; cookiesession1=678B2869D8DC46C3E2719214E5116B68; JSESSIONID=0000OK4vWohOaoP2Ee3m3lEAE0n:1aevghkom",
        "Referer": "https://www.mca.gov.in/mcafoportal/viewDocuments.do",
    },
    "body": "companyOrllp=C&cartType=&__checkbox_companyChk=true&cinChk=true&__checkbox_cinChk=true&cinFDetails=L51900GJ1981PLC079859&__checkbox_llpChk=true&__checkbox_llpinChk=true&__checkbox_regStrationNumChk=true&countryOrigin=INDIA&__checkbox_stateChk=true&displayCaptcha=false&companyID=L51900GJ1981PLC079859",
    "method": "POST"
});



fetch("https://www.mca.gov.in/mcafoportal/vpdDocumentCategoryDetails.do", {
    "headers": {
        "accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7",
        "accept-language": "en-US,en;q=0.9",
        "cache-control": "max-age=0",
        "content-type": "application/x-www-form-urlencoded",
        "sec-ch-ua": "\"Microsoft Edge\";v=\"111\", \"Not(A:Brand\";v=\"8\", \"Chromium\";v=\"111\"",
        "sec-ch-ua-mobile": "?0",
        "sec-ch-ua-platform": "\"Windows\"",
        "sec-fetch-dest": "document",
        "sec-fetch-mode": "navigate",
        "sec-fetch-site": "same-origin",
        "sec-fetch-user": "?1",
        "upgrade-insecure-requests": "1"
    },
    "referrer": "https://www.mca.gov.in/mcafoportal/vpdCheckCompanyStatus.do",
    "referrerPolicy": "same-origin",
    "body": "cinFDetails=L51900GJ1981PLC079859&companyName=SIMPLEX+TRADING+AND+AGENCIES+LTD&cartType=&categoryName=CETF&finacialYear=2022",
    "method": "POST",
    "mode": "cors",
    "credentials": "include"
});

/**
 * cinFDetails: L51900GJ1981PLC079859
companyName: SIMPLEX TRADING AND AGENCIES LTD
cartType: 
categoryName: CETF
finacialYear: 2006
 * 
 * */