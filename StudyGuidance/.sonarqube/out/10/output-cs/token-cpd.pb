ó
úC:\Users\Gebruiker\OneDrive - PXL\Documenten\pxl\3AONb\IT-project\NieuwProject\Team4Talent-WebApp\StudyGuidance\StudyGuidance.Web\ApiClient\BaseApiClient.cs
	namespace 	
StudyGuidance
 
. 
Web 
. 
	ApiClient %
{ 
public		 
abstract		 
class		 
BaseApiClient		 $
{

 
	protected 
readonly 

HttpClient 

HttpClient  *
;* +
	protected 
readonly 
ILogger 
< 
BaseApiClient *
>* +
Logger, 2
;2 3
	protected 
BaseApiClient 
( 

HttpClient $

httpClient% /
,/ 0
ILogger1 8
<8 9
BaseApiClient9 F
>F G
loggerH N
)N O
{ 

HttpClient 
= 

httpClient 
?? 
throw #
new$ '!
ArgumentNullException( =
(= >
nameof> D
(D E

httpClientE O
)O P
)P Q
;Q R
Logger 	
=
 
logger 
?? 
throw 
new !
ArgumentNullException  5
(5 6
nameof6 <
(< =
logger= C
)C D
)D E
;E F
} 
	protected 
async 
Task 
< 
T 
> 
GetJsonAsync &
<& '
T' (
>( )
() *
string* 0
endpoint1 9
)9 :
{ 
try 
{ 
return 

await 

HttpClient 
. 
GetFromJsonAsync ,
<, -
T- .
>. /
(/ 0
endpoint0 8
)8 9
;9 :
} 
catch 
(	 

	Exception
 
ex 
) 
{ 
Logger 

.
 
LogError 
( 
ex 
, 
$" 
$str J
{J K
endpointK S
}S T
$strT U
"U V
)V W
;W X
} 
return 	
default
 
; 
}   
}!! 
}"" ƒ

úC:\Users\Gebruiker\OneDrive - PXL\Documenten\pxl\3AONb\IT-project\NieuwProject\Team4Talent-WebApp\StudyGuidance\StudyGuidance.Web\ApiClient\IJobApiClient.cs
	namespace 	
StudyGuidance
 
. 
Web 
. 
	ApiClient %
{ 
public 
	interface 
IJobApiClient 
{ 
Task 
< 
Job 

>
 
GetJobByIdAsync 
( 
int 
id  "
)" #
;# $
Task 
< 
List 
< 
Job 
> 
> 
GetJobsAsync 
( 
)  
;  !
Task		 
<		 
List		 
<		 
Job		 
>		 
>		  
GetJobsByFilterAsync		 &
(		& '
List		' +
<		+ ,
string		, 2
>		2 3

subdomains		4 >
,		> ?
bool		@ D

workInTeam		E O
,		O P
bool		Q U

workOnSite		V `
)		` a
;		a b
Task

 
<

 
List

 
<

 
Option

 
>

 
>

 
GetAllSubDomains

 %
(

% &
)

& '
;

' (
} 
} ‘
ùC:\Users\Gebruiker\OneDrive - PXL\Documenten\pxl\3AONb\IT-project\NieuwProject\Team4Talent-WebApp\StudyGuidance\StudyGuidance.Web\ApiClient\IQuizApiClient.cs
	namespace 	
StudyGuidance
 
. 
Web 
. 
	ApiClient %
{ 
public 

	interface 
IQuizApiClient #
{ 
Task 
< 
List 
< 
Question 
> 
> 
GetAllQuestion +
(+ ,
), -
;- .
} 
}		 ü!
õC:\Users\Gebruiker\OneDrive - PXL\Documenten\pxl\3AONb\IT-project\NieuwProject\Team4Talent-WebApp\StudyGuidance\StudyGuidance.Web\ApiClient\JobApiClient.cs
	namespace 	
StudyGuidance
 
. 
Web 
. 
	ApiClient %
{ 
public 
class 
JobApiClient 
: 
BaseApiClient *
,* +
IJobApiClient, 9
{		 
private 	
string
 
_url 
= 
$" 
$str 9
"9 :
;: ;
public 
JobApiClient 
( 

HttpClient &

httpClient' 1
,1 2
ILogger3 :
<: ;
JobApiClient; G
>G H
loggerI O
)O P
:Q R
baseS W
(W X

httpClientX b
,b c
loggerd j
)j k
{ 
} 
public 
async 
Task 
< 
List 
< 
Option %
>% &
>& '
GetAllSubDomains( 8
(8 9
)9 :
{ 	
return 
await 
GetJsonAsync %
<% &
List& *
<* +
Option+ 1
>1 2
>2 3
(3 4
$str	4 ≠
)
≠ Æ
;
Æ Ø
} 	
public 
async 
Task 
< 
List 
< 
Option %
>% &
>& '
GetAllDomains( 5
(5 6
)6 7
{ 	
return 
await 
GetJsonAsync %
<% &
List& *
<* +
Option+ 1
>1 2
>2 3
(3 4
$"4 6
{6 7
_url7 ;
}; <
$str< D
"D E
)E F
;F G
} 	
public 
async 
Task 
< 
Job 
> 
GetJobByIdAsync .
(. /
int/ 2
id3 5
)5 6
{ 
return 	
await
 
GetJsonAsync 
< 
Job  
>  !
(! "
$"" $
{$ %
_url% )
}) *
$str* 7
{7 8
id8 :
}: ;
"; <
)< =
;= >
} 
public   
async   
Task   
<   
List   
<   
Job   "
>  " #
>  # $
GetJobsAsync  % 1
(  1 2
)  2 3
{!! 	
return"" 
await"" 
GetJsonAsync"" %
<""% &
List""& *
<""* +
Job""+ .
>"". /
>""/ 0
(""0 1
$"""1 3
{""3 4
_url""4 8
}""8 9
$str""9 >
"""> ?
)""? @
;""@ A
}## 	
public%% 
async%% 
Task%% 
<%% 
List%% 
<%% 
Job%% "
>%%" #
>%%# $ 
GetJobsByFilterAsync%%% 9
(%%9 :
List%%: >
<%%> ?
string%%? E
>%%E F

subdomains%%G Q
,%%Q R
bool%%S W

workInTeam%%X b
,%%b c
bool%%d h

workOnSite%%i s
)%%s t
{&& 	
string'' 
url'' 
='' 
$"'' 
{'' 
_url''  
}''  !
$str''! :
{'': ;
string''; A
.''A B
Join''B F
(''F G
$str''G J
,''J K

subdomains''L V
)''V W
}''W X
$str''X d
{''d e

workInTeam''e o
}''o p
$str''p |
{''| }

workOnSite	''} á
}
''á à
"
''à â
;
''â ä
return(( 
await(( 
GetJsonAsync(( %
<((% &
List((& *
<((* +
Job((+ .
>((. /
>((/ 0
(((0 1
url((1 4
)((4 5
;((5 6
})) 	
}** 
}++ ú
úC:\Users\Gebruiker\OneDrive - PXL\Documenten\pxl\3AONb\IT-project\NieuwProject\Team4Talent-WebApp\StudyGuidance\StudyGuidance.Web\ApiClient\QuizApiClient.cs
	namespace 	
StudyGuidance
 
. 
Web 
. 
	ApiClient %
{ 
public 

class 
QuizApiClient 
:  
BaseApiClient! .
,. /
IQuizApiClient0 >
{ 
private 
string 
_url 
= 
$"  
$str  ?
"? @
;@ A
public		 
QuizApiClient		 
(		 

HttpClient		 '

httpClient		( 2
,		2 3
ILogger		4 ;
<		; <
BaseApiClient		< I
>		I J
logger		K Q
)		Q R
:		S T
base		U Y
(		Y Z

httpClient		Z d
,		d e
logger		f l
)		l m
{

 	
} 	
public 
async 
Task 
< 
List 
< 
Question '
>' (
>( )
GetAllQuestion* 8
(8 9
)9 :
{ 	
return 
await 
GetJsonAsync %
<% &
List& *
<* +
Question+ 3
>3 4
>4 5
(5 6
$"6 8
{8 9
_url9 =
}= >
$str> H
"H I
)I J
;J K
} 	
} 
} Ì
èC:\Users\Gebruiker\OneDrive - PXL\Documenten\pxl\3AONb\IT-project\NieuwProject\Team4Talent-WebApp\StudyGuidance\StudyGuidance.Web\Models\Job.cs
	namespace 	
StudyGuidance
 
. 
Web 
. 
Models "
{ 
public 

class 
Job 
{ 
public 
string 
? 
Name 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
? 
Domain 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
? 
	SubDomain  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string 
? 
Description "
{# $
get% (
;( )
set* -
;- .
}/ 0
public		 
bool		 

WorkInTeam		 
{		  
get		! $
;		$ %
set		& )
;		) *
}		+ ,
public

 
bool

 

WorkOnSite

 
{

  
get

! $
;

$ %
set

& )
;

) *
}

+ ,
public 
int 
JobId 
{ 
get 
; 
set  #
;# $
}% &
} 
} È
íC:\Users\Gebruiker\OneDrive - PXL\Documenten\pxl\3AONb\IT-project\NieuwProject\Team4Talent-WebApp\StudyGuidance\StudyGuidance.Web\Models\Option.cs
	namespace 	
StudyGuidance
 
. 
Web 
. 
Models "
{ 
public 

class 
Option 
{ 
public 
string 
Content 
{ 
get  #
;# $
set% (
;( )
}* +
public 
int 
OptionRelation !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
int 

QuestionId 
{ 
get  #
;# $
set% (
;( )
}* +
public 
int 
OptionId 
{ 
get !
;! "
set# &
;& '
}( )
}		 
}

 ˇ
îC:\Users\Gebruiker\OneDrive - PXL\Documenten\pxl\3AONb\IT-project\NieuwProject\Team4Talent-WebApp\StudyGuidance\StudyGuidance.Web\Models\Question.cs
	namespace 	
StudyGuidance
 
. 
Web 
. 
Models "
{ 
public 

class 
Question 
{ 
public 
List 
< 
Option 
> 
Options #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
int 

QuestionId 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
Phrase 
{ 
get "
;" #
set$ '
;' (
}) *
} 
}		 §
åC:\Users\Gebruiker\OneDrive - PXL\Documenten\pxl\3AONb\IT-project\NieuwProject\Team4Talent-WebApp\StudyGuidance\StudyGuidance.Web\Program.cs
var 
builder 
= "
WebAssemblyHostBuilder $
.$ %
CreateDefault% 2
(2 3
args3 7
)7 8
;8 9
builder		 
.		 
RootComponents		 
.		 
Add		 
<		 
App		 
>		 
(		  
$str		  &
)		& '
;		' (
builder

 
.

 
RootComponents

 
.

 
Add

 
<

 

HeadOutlet

 %
>

% &
(

& '
$str

' 4
)

4 5
;

5 6
builder 
. 
Services 
. 
AddMudServices 
(  
)  !
;! "
builder 
. 
Services 
. 
	Configure 
< 
AnimationOptions +
>+ ,
(, -
Guid- 1
.1 2
NewGuid2 9
(9 :
): ;
.; <
ToString< D
(D E
)E F
,F G
cH I
=>J L
{M N
}O P
)P Q
;Q R
builder 
. 
Services 
. 
	AddScoped 
( 
sp 
=>  
new! $

HttpClient% /
{0 1
BaseAddress2 =
=> ?
new@ C
UriD G
(G H
builderH O
.O P
HostEnvironmentP _
._ `
BaseAddress` k
)k l
}m n
)n o
;o p
builder 
. 
Services 
. 
	AddScoped 
< 
IJobApiClient (
,( )
JobApiClient* 6
>6 7
(7 8
)8 9
;9 :
builder 
. 
Services 
. 
AddBlazorBootstrap #
(# $
)$ %
;% &
await 
builder 
. 
Build 
( 
) 
. 
RunAsync 
( 
)  
;  !