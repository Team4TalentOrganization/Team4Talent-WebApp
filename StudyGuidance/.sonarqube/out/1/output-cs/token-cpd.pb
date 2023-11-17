Þ
rC:\Users\Lucah\Documents\School\2023-2024\IT-Project\Team4Talent-WebApp\StudyGuidance\StudyGuidance.Web\Program.cs
var 
builder 
= "
WebAssemblyHostBuilder $
.$ %
CreateDefault% 2
(2 3
args3 7
)7 8
;8 9
builder 
. 
RootComponents 
. 
Add 
< 
App 
> 
(  
$str  &
)& '
;' (
builder 
. 
RootComponents 
. 
Add 
< 

HeadOutlet %
>% &
(& '
$str' 4
)4 5
;5 6
builder

 
.

 
Services

 
.

 
AddMudServices

 
(

  
)

  !
;

! "
builder 
. 
Services 
. 
	AddScoped 
( 
sp 
=>  
new! $

HttpClient% /
{0 1
BaseAddress2 =
=> ?
new@ C
UriD G
(G H
builderH O
.O P
HostEnvironmentP _
._ `
BaseAddress` k
)k l
}m n
)n o
;o p
await 
builder 
. 
Build 
( 
) 
. 
RunAsync 
( 
)  
;  !