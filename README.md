### Description

A tool to pull pdf data from MCA.GOV

### Requirements

* [chrome extenxion for copy cookies](https://chrome.google.com/webstore/detail/cookie-tab-viewer/fdlghnedhhdgjjfgdpgpaaiddipafhgk?hl=en)
* [.NET 7 for your favorite OS](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

### Instructions

*	[Go to view public documents](https://www.mca.gov.in/mcafoportal/viewPublicDocumentsFilter.do).
*	Select Company CIN/FCRN.
*	Enter L17110MH1973PLC019786.
*	You will see a picture like this:


 <img src="https://user-images.githubusercontent.com/7569989/229505484-b11b6d03-a418-429b-8a54-6919c73479e5.png" width="700" />
 
 
* Then select certificates and then year 2006.

 <img src="https://user-images.githubusercontent.com/7569989/229505504-35f6bc55-7ddd-4f0f-94aa-f06d777c3422.png" width="700" />

 
*	Then open the chrome extension for cookies.

 <img src="https://user-images.githubusercontent.com/7569989/229505517-7e5b428f-af4b-4673-8524-ed4231cfeca4.png" width="700" />


* Copy cookiesession1 and paste into the software in the specified input.

 <img src="https://user-images.githubusercontent.com/7569989/229505538-d34b3f15-c4c4-4704-8dc9-da759faefff8.png" width="700" />

 
*	Copy JSESSION1 and paste into the software in the specified input.

<img src="https://user-images.githubusercontent.com/7569989/229505549-1b24b16e-0865-47fc-ba12-c082f007256d.png" width="700" />

 
*	Select the folder directory to download the excel.
* Select request type either (single list of CIN or pair of (CIN & COMPANY NAMES))
*	Make sure to copy your data from excel to avoid issues with spaces.
*	Paste the CIN from excel.

Then you should have something like this: 

<img src="https://user-images.githubusercontent.com/7569989/229506128-fffb2649-39c4-49ea-bb54-260052efccfc.png" width="700" />

Example results:

[data mca gov for L17110MH1973PLC019786](https://github.com/mota57/ToolExtractor/tree/main/download%20example)

 
