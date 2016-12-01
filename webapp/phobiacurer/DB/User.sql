-- phpMyAdmin SQL Dump
-- version 4.0.10deb1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Dec 01, 2016 at 04:53 AM
-- Server version: 5.5.44-0ubuntu0.14.04.1
-- PHP Version: 5.5.9-1ubuntu4.13

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `PhobiaCurer`
--

-- --------------------------------------------------------

--
-- Table structure for table `User`
--

CREATE TABLE IF NOT EXISTS `User` (
  `UserId` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(100) NOT NULL,
  `Token` int(11) DEFAULT NULL,
  `Level1` varchar(10000) NOT NULL DEFAULT 'Level, TimeSpent, Date',
  `Level2` varchar(10000) NOT NULL DEFAULT 'Level, TimeSpent, Date',
  `Level3` varchar(10000) NOT NULL DEFAULT 'Level, TimeSpent, Date',
  `Level4` varchar(10000) NOT NULL DEFAULT 'Level, TimeSpent, Date',
  `Level5` varchar(10000) NOT NULL DEFAULT 'Level, TimeSpent, Date',
  `PreTreatmentSurvey` varchar(80) DEFAULT NULL,
  `PostTreatmentSurvey` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `User`
--

INSERT INTO `User` (`UserId`, `Username`, `Token`, `Level1`, `Level2`, `Level3`, `Level4`, `Level5`, `PreTreatmentSurvey`, `PostTreatmentSurvey`) VALUES
(1, 'hiarora', 368854433, 'TimeSpent,Date\n20,2001-06-11 11:00\n25,2001-06-12 11:00\n10,2001-06-13 11:00\n26,2001-06-14 11:00\n30,2001-06-15 11:00\n35,2001-06-16 11:00\n37,2001-06-17 11:00\n40,2001-06-18 11:00\n43,2001-06-19 11:00\n41,2001-06-20 11:00\n47,2001-06-21 11:00\n51,2001-06-22 11:00\n57,2001-06-23 11:00\n1,2016-11-30 07:12', 'TimeSpent,Date\n20,2001-06-11 11:00\n25,2001-06-12 11:00\n10,2001-06-13 11:00\n26,2001-06-14 11:00\n30,2001-06-15 11:00\n35,2001-06-16 11:00\n37,2001-06-17 11:00\n40,2001-06-18 11:00\n43,2001-06-19 11:00\n41,2001-06-20 11:00\n47,2001-06-21 11:00\n51,2001-06-22 11:00\n57,2001-06-23 11:00', 'TimeSpent,Date\n20,2001-06-11 11:00\n25,2001-06-12 11:00\n10,2001-06-13 11:00\n26,2001-06-14 11:00\n30,2001-06-15 11:00\n35,2001-06-16 11:00\n37,2001-06-17 11:00\n40,2001-06-18 11:00\n43,2001-06-19 11:00\n41,2001-06-20 11:00\n47,2001-06-21 11:00\n51,2001-06-22 11:00\n57,2001-06-23 11:00', 'TimeSpent,Date\n20,2001-06-11 11:00\n25,2001-06-12 11:00\n10,2001-06-13 11:00\n26,2001-06-14 11:00\n30,2001-06-15 11:00\n35,2001-06-16 11:00\n37,2001-06-17 11:00\n40,2001-06-18 11:00\n43,2001-06-19 11:00\n41,2001-06-20 11:00\n47,2001-06-21 11:00\n51,2001-06-22 11:00\n57,2001-06-23 11:00', 'TimeSpent,Date\n3,2016-11-27 09:44\n2,2016-11-27 09:46\n4,2016-11-27 09:48\n1,2016-11-27 09:49\n3,2016-11-28 12:29\n3,2016-11-28 12:29\n3,2016-11-28 12:30\n3,2016-11-28 12:30\n3,2016-11-28 11:28\n3,2016-11-28 11:29\n5,2016-11-30 07:21', '0|1|0|1|0|1|0|1|0|1|0|1|0|1|0|1|0|1|0|1|0|1|0|1|0|1|0|1|0|1|0|1|0|1|0|1|0|1', NULL),
(4, 'dsingh', NULL, 'Level, TimeSpent, Date', 'Level, TimeSpent, Date', 'Level, TimeSpent, Date', 'Level, TimeSpent, Date', 'Level, TimeSpent, Date', NULL, NULL),
(6, 'bkl', NULL, 'Level, TimeSpent, Date', 'Level, TimeSpent, Date', 'Level, TimeSpent, Date', 'Level, TimeSpent, Date', 'Level, TimeSpent, Date', NULL, NULL);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
