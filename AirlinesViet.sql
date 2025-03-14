USE [master]
GO
/****** Object:  Database [AirlinesViet]    Script Date: 3/14/2025 8:02:37 AM ******/
CREATE DATABASE [AirlinesViet]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AirlinesViet', FILENAME = N'D:\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\AirlinesViet.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AirlinesViet_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\AirlinesViet_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [AirlinesViet] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AirlinesViet].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AirlinesViet] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AirlinesViet] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AirlinesViet] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AirlinesViet] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AirlinesViet] SET ARITHABORT OFF 
GO
ALTER DATABASE [AirlinesViet] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AirlinesViet] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AirlinesViet] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AirlinesViet] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AirlinesViet] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AirlinesViet] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AirlinesViet] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AirlinesViet] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AirlinesViet] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AirlinesViet] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AirlinesViet] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AirlinesViet] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AirlinesViet] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AirlinesViet] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AirlinesViet] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AirlinesViet] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AirlinesViet] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AirlinesViet] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AirlinesViet] SET  MULTI_USER 
GO
ALTER DATABASE [AirlinesViet] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AirlinesViet] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AirlinesViet] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AirlinesViet] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AirlinesViet] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AirlinesViet] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AirlinesViet] SET QUERY_STORE = ON
GO
ALTER DATABASE [AirlinesViet] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [AirlinesViet]
GO
/****** Object:  Table [dbo].[Airplanes]    Script Date: 3/14/2025 8:02:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airplanes](
	[airplane_id] [int] IDENTITY(1,1) NOT NULL,
	[model] [nvarchar](100) NULL,
	[capacity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[airplane_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Airports]    Script Date: 3/14/2025 8:02:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airports](
	[airport_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[code] [nvarchar](10) NULL,
	[city] [nvarchar](100) NULL,
	[country] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[airport_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 3/14/2025 8:02:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[booking_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[flight_id] [int] NULL,
	[seat_id] [int] NULL,
	[booking_date] [datetime] NULL,
	[status] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[booking_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flights]    Script Date: 3/14/2025 8:02:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flights](
	[flight_id] [int] IDENTITY(1,1) NOT NULL,
	[flight_number] [nvarchar](20) NULL,
	[airplane_id] [int] NULL,
	[departure_airport] [int] NULL,
	[arrival_airport] [int] NULL,
	[departure_time] [datetime] NULL,
	[arrival_time] [datetime] NULL,
	[created_by] [int] NULL,
	[status] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[flight_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[flight_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Managers]    Script Date: 3/14/2025 8:02:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Managers](
	[manager_id] [int] NOT NULL,
	[full_name] [nvarchar](100) NULL,
	[email] [nvarchar](100) NULL,
	[phone] [nvarchar](20) NULL,
	[password_hash] [nvarchar](255) NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[manager_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 3/14/2025 8:02:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[payment_id] [int] IDENTITY(1,1) NOT NULL,
	[booking_id] [int] NULL,
	[amount] [decimal](10, 2) NULL,
	[payment_date] [datetime] NULL,
	[payment_method] [nvarchar](20) NULL,
	[status] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[payment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seats]    Script Date: 3/14/2025 8:02:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seats](
	[seat_id] [int] IDENTITY(1,1) NOT NULL,
	[flight_id] [int] NULL,
	[seat_number] [nvarchar](10) NULL,
	[class] [nvarchar](20) NULL,
	[is_available] [bit] NULL,
	[price] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[seat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupportTickets]    Script Date: 3/14/2025 8:02:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupportTickets](
	[ticket_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[manager_id] [int] NULL,
	[subject] [nvarchar](255) NULL,
	[message] [nvarchar](max) NULL,
	[status] [nvarchar](20) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ticket_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/14/2025 8:02:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[user_id] [int] NOT NULL,
	[full_name] [nvarchar](100) NULL,
	[email] [nvarchar](100) NULL,
	[phone] [nvarchar](20) NULL,
	[password_hash] [nvarchar](255) NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bookings] ADD  DEFAULT (getdate()) FOR [booking_date]
GO
ALTER TABLE [dbo].[Payments] ADD  DEFAULT (getdate()) FOR [payment_date]
GO
ALTER TABLE [dbo].[Seats] ADD  DEFAULT ((1)) FOR [is_available]
GO
ALTER TABLE [dbo].[SupportTickets] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[SupportTickets] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD FOREIGN KEY([flight_id])
REFERENCES [dbo].[Flights] ([flight_id])
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD FOREIGN KEY([seat_id])
REFERENCES [dbo].[Seats] ([seat_id])
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD FOREIGN KEY([airplane_id])
REFERENCES [dbo].[Airplanes] ([airplane_id])
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD FOREIGN KEY([arrival_airport])
REFERENCES [dbo].[Airports] ([airport_id])
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD FOREIGN KEY([created_by])
REFERENCES [dbo].[Managers] ([manager_id])
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD FOREIGN KEY([departure_airport])
REFERENCES [dbo].[Airports] ([airport_id])
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD FOREIGN KEY([booking_id])
REFERENCES [dbo].[Bookings] ([booking_id])
GO
ALTER TABLE [dbo].[Seats]  WITH CHECK ADD FOREIGN KEY([flight_id])
REFERENCES [dbo].[Flights] ([flight_id])
GO
ALTER TABLE [dbo].[SupportTickets]  WITH CHECK ADD FOREIGN KEY([manager_id])
REFERENCES [dbo].[Managers] ([manager_id])
GO
ALTER TABLE [dbo].[SupportTickets]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD CHECK  (([status]='Cancelled' OR [status]='Confirmed' OR [status]='Pending'))
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD CHECK  (([status]='Completed' OR [status]='Cancelled' OR [status]='Delayed' OR [status]='Scheduled'))
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD CHECK  (([payment_method]='Bank Transfer' OR [payment_method]='PayPal' OR [payment_method]='Debit Card' OR [payment_method]='Credit Card'))
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD CHECK  (([status]='Failed' OR [status]='Completed' OR [status]='Pending'))
GO
ALTER TABLE [dbo].[Seats]  WITH CHECK ADD  CONSTRAINT [CK_Seats_Class] CHECK  (([class]='BUSINESS' OR [class]='skyBOSS' OR [class]='Deluxe' OR [class]='Eco'))
GO
ALTER TABLE [dbo].[Seats] CHECK CONSTRAINT [CK_Seats_Class]
GO
ALTER TABLE [dbo].[SupportTickets]  WITH CHECK ADD CHECK  (([status]='Closed' OR [status]='In Progress' OR [status]='Open'))
GO
USE [master]
GO
ALTER DATABASE [AirlinesViet] SET  READ_WRITE 
GO
