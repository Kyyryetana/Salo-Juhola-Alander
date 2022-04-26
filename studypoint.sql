-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 26.04.2022 klo 08:28
-- Palvelimen versio: 10.4.22-MariaDB
-- PHP Version: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `studypoint`
--

-- --------------------------------------------------------

--
-- Rakenne taululle `kayttajat`
--

CREATE TABLE `kayttajat` (
  `sahkoposti` varchar(50) NOT NULL,
  `etunimi` varchar(25) NOT NULL,
  `sukunimi` varchar(25) NOT NULL,
  `salasana` varchar(50) NOT NULL,
  `kID` int(15) DEFAULT NULL,
  `admin` varchar(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Rakenne taululle `lataukset`
--

CREATE TABLE `lataukset` (
  `lID` int(15) NOT NULL,
  `linkki` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Rakenne taululle `palaute`
--

CREATE TABLE `palaute` (
  `pID` int(15) NOT NULL,
  `etunimi` varchar(50) DEFAULT NULL,
  `sahkoposti` varchar(50) DEFAULT NULL,
  `palaute` text NOT NULL,
  `tilanne` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Rakenne taululle `uudetasiat`
--

CREATE TABLE `uudetasiat` (
  `uID` int(15) NOT NULL,
  `asia` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `kayttajat`
--
ALTER TABLE `kayttajat`
  ADD PRIMARY KEY (`sahkoposti`),
  ADD UNIQUE KEY `sahkoposti` (`sahkoposti`),
  ADD UNIQUE KEY `kID` (`kID`);

--
-- Indexes for table `lataukset`
--
ALTER TABLE `lataukset`
  ADD PRIMARY KEY (`lID`),
  ADD UNIQUE KEY `lID` (`lID`);

--
-- Indexes for table `palaute`
--
ALTER TABLE `palaute`
  ADD PRIMARY KEY (`pID`),
  ADD UNIQUE KEY `pID` (`pID`);

--
-- Indexes for table `uudetasiat`
--
ALTER TABLE `uudetasiat`
  ADD PRIMARY KEY (`uID`),
  ADD UNIQUE KEY `uID` (`uID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
