-- phpMyAdmin SQL Dump
-- version 3.5.2.2
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Apr 19, 2013 at 09:25 AM
-- Server version: 5.5.27
-- PHP Version: 5.4.7

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `cmanagement`
--

-- --------------------------------------------------------

--
-- Table structure for table `tblarticle`
--

CREATE TABLE IF NOT EXISTS `tblarticle` (
  `articleid` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(20) NOT NULL,
  `uid` int(11) NOT NULL,
  `category` varchar(20) NOT NULL,
  `article` varchar(300) NOT NULL,
  `datetime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`articleid`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=28 ;

--
-- Dumping data for table `tblarticle`
--

INSERT INTO `tblarticle` (`articleid`, `title`, `uid`, `category`, `article`, `datetime`) VALUES
(19, 'Slender', 7, 'Horror', 'I was playing this game and I was like scared oh fuck... Haiii! Hassle! D: When my character turned around there was this man I was really scared xD', '2013-04-16 05:16:21'),
(20, 'Ozine Fest', 8, 'Anime', 'Another anime day in my life. Pictures with cosplayers and shit. Baka mabuhay xD', '2013-04-16 05:14:45'),
(21, 'ImagineCup', 9, 'Technology', 'Sali tayo sa imaginecup guys #geryl #chad #imaginecup #mike #mozilla wooooo!', '2013-04-16 05:12:39'),
(22, 'PEAR', 7, 'Technology', 'Pear quiets magic', '2013-04-18 06:04:17'),
(23, 'Hay', 7, 'Comedy', 'When Im bored', '2013-04-18 06:05:09'),
(24, 'The Marcucu Daily', 9, 'Technology', 'asdasd', '2013-04-19 04:02:16'),
(25, 'Hassle Shit', 8, 'Classic', 'Classic Geryl', '2013-04-19 04:04:17'),
(26, 'asd', 11, 'asd', 'asd', '2013-04-19 04:08:01'),
(27, 'WEBDEVT!', 12, 'Technology', 'Hahahahahahahaha!', '2013-04-19 05:26:13');

-- --------------------------------------------------------

--
-- Table structure for table `tblcomments`
--

CREATE TABLE IF NOT EXISTS `tblcomments` (
  `commentid` int(11) NOT NULL AUTO_INCREMENT,
  `uid` int(11) NOT NULL,
  `datetime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `comment` varchar(200) NOT NULL,
  `articleid` int(11) NOT NULL,
  PRIMARY KEY (`commentid`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=23 ;

--
-- Dumping data for table `tblcomments`
--

INSERT INTO `tblcomments` (`commentid`, `uid`, `datetime`, `comment`, `articleid`) VALUES
(6, 7, '2013-04-16 05:06:10', 'haaaaiiiii', 19),
(7, 8, '2013-04-16 05:08:40', 'baka mabuhay! xD', 19),
(8, 9, '2013-04-16 05:12:55', 'Wooooo!', 19),
(9, 10, '2013-04-16 05:13:21', 'Scare shit', 19),
(10, 10, '2013-04-16 05:13:31', 'Anime shit', 20),
(11, 10, '2013-04-16 05:13:39', 'zzzzz', 21),
(12, 8, '2013-04-16 05:15:08', 'ulol ka gago xD', 20),
(16, 10, '2013-04-18 05:22:32', 'ddd', 19),
(17, 10, '2013-04-18 05:56:14', 'Ahihihi', 19),
(18, 7, '2013-04-18 06:03:56', 'I gave up on PEAR', 22),
(19, 9, '2013-04-19 04:01:59', 'asdasdasdasd', 24),
(20, 8, '2013-04-19 04:03:14', 'Hassle shit', 24),
(21, 11, '2013-04-19 04:08:23', 'asd', 26),
(22, 12, '2013-04-19 05:26:30', 'Nice! :D', 27);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `uid` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(30) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  `name` varchar(100) DEFAULT NULL,
  `email` varchar(70) DEFAULT NULL,
  PRIMARY KEY (`uid`),
  UNIQUE KEY `username` (`username`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=13 ;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`uid`, `username`, `password`, `name`, `email`) VALUES
(7, 'Wynsel', 'b8a91e5830b096cfa333d37d5705aefd', 'Chadwyn Gonzales', 'wynsel123@yahoo.com'),
(8, 'Bocchan', '882fa79a0ad5871d5a118b73295bfbd1', 'Geryl Gonido', 'geryl123@yahoo.com'),
(9, 'Heyitsmarcucu', '49c167d7cd66dc64a474c261860ba50f', 'Marcus Ang', 'heyitsmarcucu@yahoo.com'),
(10, 'Mykz', '18126e7bd3f84b3f3e4df094def5b7de', 'Mike Lau', 'mykz949@gmail.com'),
(11, 'asd', '7815696ecbf1c96e6894b779456d330e', 'asd', 'asd@gmail.com'),
(12, 'uyb', '09f609ac8513d005b73d1eb159ba6274', 'Ben Uy', 'ben_uy@yahoo.com');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
