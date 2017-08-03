insert into MDMLog (LogID,LogDate,LogLevel,MethodInfo,Message) values (@LogID,@LogDate,@LogLevel,@MethodInfo,@Message)

if not exists (select 1 from  sysobjects where  id = object_id('MDMLog') and   type = 'U')
begin
   create table MDMLog (
   LogID         varchar(36)      not null,
   LogDate       datetime         null,
   LogLevel      varchar(10)      null,
   MethodInfo    varchar(2000)    null,
   Message       varchar(2000)    null,
   constraint PK_LogID primary key (LogID)
)
end
go

if not exists (select 1 from  sysobjects where  id = object_id('MDMLogCategory') and   type = 'U')
begin
   create table MDMLogCategory (
   LogCategory_BH         varchar(40)          not null,
   LogCategory_MC         varchar(100)         null,
   LogCategory_MiniLevel      char(1)         null,
   LogCategory_Listeners     varchar(2000)         null,
   constraint PK_LogCategory primary key (LogCategory_BH)
)
end
go

if not exists (select 1 from  sysobjects where  id = object_id('MDMLogListener') and   type = 'U')
begin
   create table MDMLogListener (
   LogListener_BH         varchar(40)     not null,
   LogListener_MC         varchar(100)         null,
   LogListener_DestinationType     char(1)         null,
   LogListener_ConnString       varchar(1000)         null,
   LogListener_InsertSql  varchar(2000)         null,
   LogListener_FilePath   varchar(100)         null,
   LogListener_FileName   varchar(100)          null,
   LogListener_AppendToFile     char(1)       null,
   LogListener_DateFormatter      varchar(100)        null, 
   LogListener_MaximumFileSize    int       null    ,
   LogListener_LayoutHeader     varchar(2000)          null,
   LogListener_LayoutContent    varchar(2000)       null,
   LogListener_LayoutFooter     varchar(2000)      null,
   constraint PK_LogListener primary key (LogListener_BH)
)
end
go

declare vCount int :=0;
begin
	select count(1) into vCount from user_all_tables where upper(table_name) = upper('MDMLog');
	if(vCount <= 0) then
		Execute immediate ('create table MDMLog (
		   LogID         varchar(36)      not null,
		   LogDate       datetime         null,
		   LogLevel      varchar(10)      null,
		   MethodInfo    varchar(2000)    null,
		   Message       varchar(2000)    null,
		   constraint PK_LogID primary key (LogID)
		)');
	end if;
end;
GO

declare vCount int :=0;
begin
	select count(1) into vCount from user_all_tables where upper(table_name) = upper('MDMLogCategory');
	if(vCount <= 0) then
		Execute immediate ('create table MDMLogCategory (
		   LogCategory_BH         varchar(40)          not null,
		   LogCategory_MC         varchar(100)         null,
		   LogCategory_MiniLevel      char(1)         null,
		   LogCategory_Listeners     varchar(2000)         null,
		   constraint PK_LogCategory primary key (LogCategory_BH)
		)');
	end if;
end;
GO

declare vCount int :=0;
begin
	select count(1) into vCount from user_all_tables where upper(table_name) = upper('MDMLogListener');
	if(vCount <= 0) then
		Execute immediate ('create table MDMLogListener (
		   LogListener_BH         varchar(40)     not null,
		   LogListener_MC         varchar(100)         null,
		   LogListener_DestinationType     char(1)         null,
		   LogListener_ConnString       varchar(1000)         null,
		   LogListener_InsertSql  varchar(2000)         null,
		   LogListener_FilePath   varchar(100)         null,
		   LogListener_FileName   varchar(100)          null,
		   LogListener_AppendToFile     char(1)       null,
		   LogListener_DateFormatter      varchar(100)        null, 
		   LogListener_MaximumFileSize    int       null    ,
		   LogListener_LayoutHeader     varchar(2000)          null,
		   LogListener_LayoutContent    varchar(2000)       null,
		   LogListener_LayoutFooter     varchar(2000)      null,
		   constraint PK_LogListener primary key (LogListener_BH)
		)');
	end if;
end;
GO