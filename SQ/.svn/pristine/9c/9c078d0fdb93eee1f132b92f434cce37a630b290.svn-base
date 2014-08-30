-- MySqlBackup.NET dump 1.5.7 beta
-- Dump time: 2014-08-15 15:43:36
-- ------------------------------------------------------
-- Server version	5.5.32 MySQL Community Server (GPL)


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES latin1 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


--
-- Definition of table `tbl_brand`
--

DROP TABLE IF EXISTS `tbl_brand`;
CREATE TABLE IF NOT EXISTS `tbl_brand` (
  `ctrl_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`ctrl_id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_brand`
--

/*!40000 ALTER TABLE `tbl_brand` DISABLE KEYS */;
INSERT INTO `tbl_brand` (`ctrl_id`,`name`) VALUES
(1,'ABS Computer Technologies'),
(2,'Ace Computers'),
(3,'Acer'),
(4,'ASRock'),
(5,'Apple'),
(6,'Asus'),
(7,'Chip PC'),
(8,'Dell'),
(9,'Alienware'),
(10,'Hewlett-Packard'),
(11,'IBM'),
(12,'Intel'),
(13,'Jetta International'),
(14,'Kontron AG'),
(15,'LanSlide Gaming PCs'),
(16,'Lenovo'),
(17,'LG'),
(18,'Medion'),
(19,'Micron'),
(20,'Microsoft'),
(21,'2'),
(22,'3');
/*!40000 ALTER TABLE `tbl_brand` ENABLE KEYS */;


--
-- Definition of table `tbl_company`
--

DROP TABLE IF EXISTS `tbl_company`;
CREATE TABLE IF NOT EXISTS `tbl_company` (
  `ctrl_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`ctrl_id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_company`
--

/*!40000 ALTER TABLE `tbl_company` DISABLE KEYS */;
INSERT INTO `tbl_company` (`ctrl_id`,`name`) VALUES
(1,'AtomIT'),
(2,'ABS-CBN Corporation'),
(3,'Aliw Broadcasting Corporation'),
(4,'Eagle Broadcasting Corporation'),
(5,'GMA Network, Inc.'),
(6,'Manila Broadcasting Company'),
(7,'Manila Bulletin'),
(8,'Manila Times'),
(9,'Philippine Broadcasting Service'),
(10,'Philippine Star'),
(11,'Pinoy Exchange'),
(12,'Radio Mindanao Network Inc.'),
(13,'Regal Entertainment'),
(14,'Solar Entertainment Corporation'),
(15,'Star Cinema'),
(16,'Tiger 22 Media Corporation'),
(17,'Viva Entertainment'),
(18,'ZOE Broadcasting Network'),
(23,'1'),
(24,'2');
/*!40000 ALTER TABLE `tbl_company` ENABLE KEYS */;


--
-- Definition of table `tbl_login`
--

DROP TABLE IF EXISTS `tbl_login`;
CREATE TABLE IF NOT EXISTS `tbl_login` (
  `ctrl_id` int(11) NOT NULL AUTO_INCREMENT,
  `fname` varchar(255) NOT NULL,
  `lname` varchar(255) NOT NULL,
  `mname` varchar(255) NOT NULL,
  `uname` varchar(255) NOT NULL,
  `upass` varchar(255) CHARACTER SET latin1 COLLATE latin1_general_cs NOT NULL,
  `cnum` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `position` varchar(255) NOT NULL,
  `initial` tinytext NOT NULL,
  PRIMARY KEY (`ctrl_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_login`
--

/*!40000 ALTER TABLE `tbl_login` DISABLE KEYS */;
INSERT INTO `tbl_login` (`ctrl_id`,`fname`,`lname`,`mname`,`uname`,`upass`,`cnum`,`email`,`position`,`initial`) VALUES
(1,'Admin','Admin','','admin','admin','','','Supervisor','AA');
/*!40000 ALTER TABLE `tbl_login` ENABLE KEYS */;


--
-- Definition of table `tbl_sq_detail`
--

DROP TABLE IF EXISTS `tbl_sq_detail`;
CREATE TABLE IF NOT EXISTS `tbl_sq_detail` (
  `ctrl_id` int(11) NOT NULL AUTO_INCREMENT,
  `sq_main_id` int(11) NOT NULL,
  `category` varchar(255) NOT NULL,
  `brand_id` int(11) NOT NULL,
  `item_name` varchar(255) NOT NULL,
  `quantity` int(11) NOT NULL,
  `uom` varchar(255) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `total_price` decimal(10,2) NOT NULL,
  `dealer_price` decimal(10,2) NOT NULL,
  `margin` int(11) NOT NULL,
  `vat_type` varchar(255) NOT NULL,
  `free1` varchar(255) NOT NULL,
  `amount1` decimal(10,2) NOT NULL,
  `free2` varchar(255) NOT NULL,
  `amount2` decimal(10,2) NOT NULL,
  `free3` varchar(255) NOT NULL,
  `amount3` decimal(10,2) NOT NULL,
  `note` longtext NOT NULL,
  `availability` varchar(255) NOT NULL,
  `status` varchar(255) NOT NULL,
  PRIMARY KEY (`ctrl_id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_sq_detail`
--

/*!40000 ALTER TABLE `tbl_sq_detail` DISABLE KEYS */;
INSERT INTO `tbl_sq_detail` (`ctrl_id`,`sq_main_id`,`category`,`brand_id`,`item_name`,`quantity`,`uom`,`price`,`total_price`,`dealer_price`,`margin`,`vat_type`,`free1`,`amount1`,`free2`,`amount2`,`free3`,`amount3`,`note`,`availability`,`status`) VALUES
(1,4,'Category 1',1,'Laptop',1,'Pieces',20000.00,20000.00,15000.00,25,'Vat-Include','Sample 1',150.00,'Sample 2',0.00,'',150.00,'Laptop','On Stock','Approved'),
(2,4,'Category 1',1,'Digital Camera',1,'Pieces',7000.00,7000.00,5000.00,29,'Vat-Include','Sample 3',0.00,'',0.00,'',0.00,'Digital Camera','On Stock','New'),
(3,5,'Category 1',9,'Laptop',1,'Pieces',15000.00,15000.00,13000.00,13,'Vat-Include','',0.00,'',0.00,'',0.00,'Laptop','On Stock','New'),
(4,5,'Category 1',5,'Iphone',1,'Pieces',7000.00,7000.00,5000.00,26,'Vat-Include','Power Bank',150.00,'',0.00,'',0.00,'Iphone','On Stock','New'),
(7,23,'Category 1',21,'3',1,'4',2.00,2.00,1.00,50,'Vat-Include','',0.00,'',0.00,'',0.00,'5','On Stock','Approved'),
(8,23,'Category 1',22,'4',1,'5',5.00,5.00,2.00,60,'Vat-Include','',0.00,'',0.00,'',0.00,'6','On Stock','Approved'),
(9,23,'Category 1',21,'3',1,'4',2.00,2.00,1.00,50,'Vat-Include','',0.00,'',0.00,'',0.00,'5','On Stock','Approved'),
(12,27,'Category 1',1,'Laptop',1,'Pieces',20000.00,20000.00,15000.00,25,'Vat-Include','Sample 1',150.00,'Sample 2',0.00,'',150.00,'Laptop','On Stock','Approved'),
(13,27,'Category 1',1,'Digital Camera',1,'Pieces',7000.00,7000.00,5000.00,29,'Vat-Include','Sample 3',0.00,'',0.00,'',0.00,'Digital Camera','On Stock','New'),
(14,28,'Category 1',1,'Laptop',1,'Pieces',20000.00,20000.00,15000.00,25,'Vat-Include','Sample 1',150.00,'Sample 2',0.00,'',150.00,'Laptop','On Stock','Approved'),
(15,28,'Category 1',1,'Digital Camera',1,'Pieces',7000.00,7000.00,5000.00,29,'Vat-Include','Sample 3',0.00,'',0.00,'',0.00,'Digital Camera','On Stock','New'),
(16,29,'Category 1',1,'Laptop',1,'Pieces',20000.00,20000.00,15000.00,25,'Vat-Include','Sample 1',150.00,'Sample 2',0.00,'',150.00,'Laptop','On Stock','Approved'),
(17,29,'Category 1',1,'Digital Camera',1,'Pieces',7000.00,7000.00,5000.00,29,'Vat-Include','Sample 3',0.00,'',0.00,'',0.00,'Digital Camera','On Stock','New'),
(18,30,'Category 1',1,'Laptop',1,'Pieces',20000.00,20000.00,15000.00,25,'Vat-Include','Sample 1',150.00,'Sample 2',0.00,'',150.00,'Laptop','On Stock','Approved'),
(19,30,'Category 1',1,'Digital Camera',1,'Pieces',7000.00,7000.00,5000.00,29,'Vat-Include','Sample 3',0.00,'',0.00,'',0.00,'Digital Camera','On Stock','New'),
(20,31,'Category 1',1,'Laptop',1,'Pieces',20000.00,20000.00,15000.00,25,'Vat-Include','Sample 1',150.00,'Sample 2',0.00,'',150.00,'Laptop','On Stock','Approved'),
(21,31,'Category 1',1,'Digital Camera',1,'Pieces',7000.00,7000.00,5000.00,29,'Vat-Include','Sample 3',0.00,'',0.00,'',0.00,'Digital Camera','On Stock','New'),
(22,32,'Category 1',1,'Laptop',1,'Pieces',20000.00,20000.00,15000.00,25,'Vat-Include','Sample 1',150.00,'Sample 2',0.00,'',150.00,'Laptop','On Stock','Approved'),
(23,32,'Category 1',1,'Digital Camera',1,'Pieces',7000.00,7000.00,5000.00,29,'Vat-Include','Sample 3',0.00,'',0.00,'',0.00,'Digital Camera','On Stock','Approved'),
(24,33,'Category 1',1,'Laptop',1,'Pieces',20000.00,20000.00,15000.00,25,'Vat-Include','Sample 1',150.00,'Sample 2',0.00,'',150.00,'Laptop','On Stock','Rejected'),
(25,33,'Category 1',1,'Digital Camera',1,'Pieces',7000.00,7000.00,5000.00,29,'Vat-Include','Sample 3',0.00,'',0.00,'',0.00,'Digital Camera','On Stock','Rejected'),
(26,34,'Category 1',1,'Laptop',1,'Pieces',20000.00,20000.00,15000.00,25,'Vat-Include','Sample 1',150.00,'Sample 2',0.00,'',150.00,'Laptop','On Stock','Rejected'),
(27,34,'Category 1',1,'Digital Camera',1,'Pieces',7000.00,7000.00,5000.00,29,'Vat-Include','Sample 3',0.00,'',0.00,'',0.00,'Digital Camera','On Stock','Rejected');
/*!40000 ALTER TABLE `tbl_sq_detail` ENABLE KEYS */;


--
-- Definition of table `tbl_sq_main`
--

DROP TABLE IF EXISTS `tbl_sq_main`;
CREATE TABLE IF NOT EXISTS `tbl_sq_main` (
  `ctrl_id` int(11) NOT NULL AUTO_INCREMENT,
  `sqno` varchar(255) NOT NULL,
  `company_id` int(11) NOT NULL,
  `email` varchar(255) NOT NULL,
  `contact_no` varchar(255) NOT NULL,
  `faxno` varchar(255) NOT NULL,
  `todeliver` longtext NOT NULL,
  `tobill` longtext NOT NULL,
  `attention` varchar(255) NOT NULL,
  `availability` longtext NOT NULL,
  `terms_id` int(11) NOT NULL,
  `delivery` longtext NOT NULL,
  `validity` longtext NOT NULL,
  `cancellation` longtext NOT NULL,
  `status` varchar(255) NOT NULL,
  `revision` int(11) NOT NULL,
  `create_date` datetime NOT NULL,
  PRIMARY KEY (`ctrl_id`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_sq_main`
--

/*!40000 ALTER TABLE `tbl_sq_main` DISABLE KEYS */;
INSERT INTO `tbl_sq_main` (`ctrl_id`,`sqno`,`company_id`,`email`,`contact_no`,`faxno`,`todeliver`,`tobill`,`attention`,`availability`,`terms_id`,`delivery`,`validity`,`cancellation`,`status`,`revision`,`create_date`) VALUES
(1,'AA140812001',2,'abs.cbn@yahoo.com.ph','123-4567','123-4567','Philippines','Philippines','Manager','For items on-stock, please allow 3-5 days to process order\nFor items not on-stock, please allow 30-45 days leadtime',1,'Free delivery for PO with minimum order of Php 5,00.00 within Metro Manila, and minimum amount of Php 10,000.00 for Laguna, Batangas and Cavite.','Price quoted is valid for 15 days from date of quotation.','A 25% restocking fee (based on purchas order amount) for cancelled or returned orders, likewise prodct echanges and only be done 3 days after delivery. Order basis items cannot be returned nor cancelled.','New',0,'2014-08-12 00:00:00'),
(3,'AA140812002',24,'2','2','2','2','2','2','2',14,'2','2','2','New',0,'2014-08-12 00:00:00'),
(4,'AA140812003',2,'abs.cbn@yahoo.com.ph','123-4567','123-4567','Philippines','Philippines','Manager','For items on-stock, please allow 3-5 days to process order\r\nFor items not on-stock, please allow 30-45 days leadtime',1,'Free delivery for PO with minimum order of Php 5,00.00 within Metro Manila, and minimum amount of Php 10,000.00 for Laguna, Batangas and Cavite.','Price quoted is valid for 15 days from date of quotation.','A 25% restocking fee (based on purchas order amount) for cancelled or returned orders, likewise prodct echanges and only be done 3 days after delivery. Order basis items cannot be returned nor cancelled.','Confirmed',0,'2014-08-12 00:00:00'),
(5,'AA140813001',5,'gma@yahoo.com.ph','123-45678','123-45678','Philippines','Philippines','Supervisor','For items on-stock, please allow 3-5 days to process order\r\nFor items not on-stock, please allow 30-45 days leadtime',1,'Free delivery for PO with minimum order of Php 5,00.00 within Metro Manila, and minimum amount of Php 10,000.00 for Laguna, Batangas and Cavite.','Price quoted is valid for 15 days from date of quotation.','A 25% restocking fee (based on purchas order amount) for cancelled or returned orders, likewise prodct echanges and only be done 3 days after delivery. Order basis items cannot be returned nor cancelled.','New',0,'2014-08-13 00:00:00'),
(6,'AA140813002',3,'1','1','1','1','1','1','1',1,'1','1','1','New',0,'2014-08-13 01:52:29'),
(23,'AA140814001',2,'1','2','34','4','5','6','7',15,'9','10','11','Confirmed',0,'2014-08-14 02:05:52'),
(27,'AA140812003',2,'abs.cbn@yahoo.com.ph','123-4567','123-4567','Philippines','Philippines','Manager','For items on-stock, please allow 3-5 days to process order\r\nFor items not on-stock, please allow 30-45 days leadtime',1,'Free delivery for PO with minimum order of Php 5,00.00 within Metro Manila, and minimum amount of Php 10,000.00 for Laguna, Batangas and Cavite.','Price quoted is valid for 15 days from date of quotation.','A 25% restocking fee (based on purchas order amount) for cancelled or returned orders, likewise prodct echanges and only be done 3 days after delivery. Order basis items cannot be returned nor cancelled.','Confirmed',1,'2014-08-15 10:27:45'),
(28,'AA140812003',2,'abs.cbn@yahoo.com.ph','123-4567','123-4567','Philippines','Philippines','Manager','For items on-stock, please allow 3-5 days to process order\r\nFor items not on-stock, please allow 30-45 days leadtime',1,'Free delivery for PO with minimum order of Php 5,00.00 within Metro Manila, and minimum amount of Php 10,000.00 for Laguna, Batangas and Cavite.','Price quoted is valid for 15 days from date of quotation.','A 25% restocking fee (based on purchas order amount) for cancelled or returned orders, likewise prodct echanges and only be done 3 days after delivery. Order basis items cannot be returned nor cancelled.','Confirmed',2,'2014-08-15 10:28:28'),
(29,'AA140812003',2,'abs.cbn@yahoo.com.ph','123-4567','123-4567','Philippines','Philippines','Manager','For items on-stock, please allow 3-5 days to process order\r\nFor items not on-stock, please allow 30-45 days leadtime',1,'Free delivery for PO with minimum order of Php 5,00.00 within Metro Manila, and minimum amount of Php 10,000.00 for Laguna, Batangas and Cavite.','Price quoted is valid for 15 days from date of quotation.','A 25% restocking fee (based on purchas order amount) for cancelled or returned orders, likewise prodct echanges and only be done 3 days after delivery. Order basis items cannot be returned nor cancelled.','Approved',3,'2014-08-15 10:28:51'),
(30,'AA140812003',2,'abs.cbn@yahoo.com.ph','123-4567','123-4567','Philippines','Philippines','Manager','For items on-stock, please allow 3-5 days to process order\r\nFor items not on-stock, please allow 30-45 days leadtime',1,'Free delivery for PO with minimum order of Php 5,00.00 within Metro Manila, and minimum amount of Php 10,000.00 for Laguna, Batangas and Cavite.','Price quoted is valid for 15 days from date of quotation.','A 25% restocking fee (based on purchas order amount) for cancelled or returned orders, likewise prodct echanges and only be done 3 days after delivery. Order basis items cannot be returned nor cancelled.','Confirmed',4,'2014-08-15 10:28:55'),
(31,'AA140812003',2,'abs.cbn@yahoo.com.ph','123-4567','123-4567','Philippines','Philippines','Manager','For items on-stock, please allow 3-5 days to process order\r\nFor items not on-stock, please allow 30-45 days leadtime',1,'Free delivery for PO with minimum order of Php 5,00.00 within Metro Manila, and minimum amount of Php 10,000.00 for Laguna, Batangas and Cavite.','Price quoted is valid for 15 days from date of quotation.','A 25% restocking fee (based on purchas order amount) for cancelled or returned orders, likewise prodct echanges and only be done 3 days after delivery. Order basis items cannot be returned nor cancelled.','Confirmed',5,'2014-08-15 10:31:07'),
(32,'AA140812003',2,'abs.cbn@yahoo.com.ph','123-4567','123-4567','Philippines','Philippines','Manager','For items on-stock, please allow 3-5 days to process order\r\nFor items not on-stock, please allow 30-45 days leadtime',1,'Free delivery for PO with minimum order of Php 5,00.00 within Metro Manila, and minimum amount of Php 10,000.00 for Laguna, Batangas and Cavite.','Price quoted is valid for 15 days from date of quotation.','A 25% restocking fee (based on purchas order amount) for cancelled or returned orders, likewise prodct echanges and only be done 3 days after delivery. Order basis items cannot be returned nor cancelled.','Confirmed',6,'2014-08-15 10:38:21'),
(33,'AA140812003',2,'abs.cbn@yahoo.com.ph','123-4567','123-4567','Philippines','Philippines','Manager','For items on-stock, please allow 3-5 days to process order\r\nFor items not on-stock, please allow 30-45 days leadtime',1,'Free delivery for PO with minimum order of Php 5,00.00 within Metro Manila, and minimum amount of Php 10,000.00 for Laguna, Batangas and Cavite.','Price quoted is valid for 15 days from date of quotation.','A 25% restocking fee (based on purchas order amount) for cancelled or returned orders, likewise prodct echanges and only be done 3 days after delivery. Order basis items cannot be returned nor cancelled.','Approved',7,'2014-08-15 10:38:42'),
(34,'AA140812003',2,'abs.cbn@yahoo.com.ph','123-4567','123-4567','Philippines','Philippines','Manager','For items on-stock, please allow 3-5 days to process order\r\nFor items not on-stock, please allow 30-45 days leadtime',1,'Free delivery for PO with minimum order of Php 5,00.00 within Metro Manila, and minimum amount of Php 10,000.00 for Laguna, Batangas and Cavite.','Price quoted is valid for 15 days from date of quotation.','A 25% restocking fee (based on purchas order amount) for cancelled or returned orders, likewise prodct echanges and only be done 3 days after delivery. Order basis items cannot be returned nor cancelled.','Approved',8,'2014-08-15 10:38:58');
/*!40000 ALTER TABLE `tbl_sq_main` ENABLE KEYS */;


--
-- Definition of table `tbl_terms`
--

DROP TABLE IF EXISTS `tbl_terms`;
CREATE TABLE IF NOT EXISTS `tbl_terms` (
  `ctrl_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`ctrl_id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_terms`
--

/*!40000 ALTER TABLE `tbl_terms` DISABLE KEYS */;
INSERT INTO `tbl_terms` (`ctrl_id`,`name`) VALUES
(1,'Term 1'),
(2,'Term 2'),
(3,'Term 3'),
(4,'Term 4'),
(13,'1'),
(14,'2'),
(15,'8');
/*!40000 ALTER TABLE `tbl_terms` ENABLE KEYS */;


/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
