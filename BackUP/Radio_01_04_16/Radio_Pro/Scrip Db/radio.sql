
CREATE TABLE IF NOT EXISTS `admin` (
  `id` int(11) NOT NULL auto_increment,
  `userName` varchar(200) NOT NULL,
  `password` varchar(200) NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`id`, `userName`, `password`) VALUES
(1, 'admin', 'admin'),
(2, 'abhishek', '123456');

-- --------------------------------------------------------

--
-- Table structure for table `csvfile`
--

CREATE TABLE IF NOT EXISTS `csvfile` (
  `pt_transaction` int(100) NOT NULL auto_increment,
  `radioPatientRptDate` varchar(200) default NULL,
  `radioPatientsName` varchar(200) default NULL,
  `radioPatientsId` varchar(200) default NULL,
  `radioDoctorId` varchar(200) default NULL,
  `radioName` varchar(200) default NULL,
  `cut` varchar(200) default NULL,
  `invest` varchar(200) default NULL,
  `deviceId` varchar(200) default NULL,
  `userName` varchar(200) default NULL,
  `status` varchar(200) default NULL,
  PRIMARY KEY  (`pt_transaction`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=23 ;

-- --------------------------------------------------------

--
-- Table structure for table `cut`
--

CREATE TABLE IF NOT EXISTS `cut` (
  `cutId` int(11) NOT NULL auto_increment,
  `radioPatientsId` varchar(200) NOT NULL,
  `radioDoctorId` varchar(200) NOT NULL,
  `radioCategory` varchar(200) NOT NULL,
  `cut` varchar(100) NOT NULL,
  PRIMARY KEY  (`cutId`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=23 ;

-- --------------------------------------------------------

--
-- Table structure for table `doctormobilenumber`
--

CREATE TABLE IF NOT EXISTS `doctormobilenumber` (
  `doctorId` varchar(100) default NULL,
  `mobileNumber` text,
  `alternateMobile1` varchar(10) NOT NULL,
  `alternateMobile2` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `doctors`
--

CREATE TABLE IF NOT EXISTS `doctors` (
  `doctorId` int(11) NOT NULL auto_increment,
  `radioTitle` varchar(100) default NULL,
  `radioDoctorId` varchar(200) NOT NULL,
  `radioName` varchar(200) NOT NULL,
  `radioAddress` varchar(300) default NULL,
  `radioPhoneRes` varchar(100) default NULL,
  `radioPhoneOffice` varchar(100) default NULL,
  `radioPhoneMobile` varchar(100) default NULL,
  `radioFax` varchar(200) default NULL,
  `radioCategory` varchar(100) default NULL,
  `areaId` varchar(200) NOT NULL,
  `alternateMobile1` varchar(100) NOT NULL,
  `alternateMobile2` varchar(100) NOT NULL,
  PRIMARY KEY  (`doctorId`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=22 ;

-- --------------------------------------------------------

--
-- Table structure for table `investigation`
--

CREATE TABLE IF NOT EXISTS `investigation` (
  `investigationId` int(11) NOT NULL auto_increment,
  `radioInvestigationId` varchar(100) NOT NULL,
  `radioInvestigationName` varchar(100) NOT NULL,
  PRIMARY KEY  (`investigationId`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=29 ;

-- --------------------------------------------------------

--
-- Table structure for table `masterarea`
--

CREATE TABLE IF NOT EXISTS `masterarea` (
  `areaId` int(11) NOT NULL auto_increment,
  `radioAreaId` varchar(100) NOT NULL,
  `radioArea` varchar(200) default NULL,
  `radioSuburb` varchar(200) default NULL,
  `radioCity` varchar(200) default NULL,
  `radioPincode` varchar(100) default NULL,
  PRIMARY KEY  (`areaId`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=29 ;

-- --------------------------------------------------------

--
-- Table structure for table `patients`
--

CREATE TABLE IF NOT EXISTS `patients` (
  `patientsId` int(11) NOT NULL auto_increment,
  `radioPatientsId` varchar(200) NOT NULL,
  `radioPatientsName` varchar(200) NOT NULL,
  `radioPatientRptDate` varchar(200) NOT NULL,
  `radioSex` varchar(100) default NULL,
  `radioAge` varchar(100) default NULL,
  `radioAgeCategory` varchar(100) default NULL,
  `radioInvestigation` varchar(100) default NULL,
  `ass_status` int(10) NOT NULL default '0',
  PRIMARY KEY  (`patientsId`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=25 ;

-- --------------------------------------------------------

--
-- Table structure for table `serverlocation`
--

CREATE TABLE IF NOT EXISTS `serverlocation` (
  `locationId` int(11) NOT NULL,
  `deviceId` text NOT NULL,
  `latitude` text NOT NULL,
  `longitude` text NOT NULL,
  `createdOn` varchar(100) NOT NULL,
  `status` int(10) NOT NULL default '0',
  PRIMARY KEY  (`locationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


CREATE TABLE IF NOT EXISTS `servertransactions` (
  `pt_transaction` int(11) NOT NULL,
  `flag` text
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL auto_increment,
  `userName` varchar(200) NOT NULL,
  `primContact` varchar(100) NOT NULL,
  `deviceId` varchar(100) NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

-- --------------------------------------------------------

--
-- Stand-in structure for view `vwpatientwithdoctorscut_csv`
--
CREATE TABLE IF NOT EXISTS `vwpatientwithdoctorscut_csv` (
`radioPatientRptDate` varchar(200)
,`radioPatientsName` varchar(200)
,`radioPatientsId` varchar(200)
,`radioDoctorId` varchar(200)
,`radioName` varchar(200)
,`cut` varchar(100)
,`radioInvestigation` varchar(100)
,`ass_status` int(10)
);
-- --------------------------------------------------------

--
-- Structure for view `vwpatientwithdoctorscut_csv`
--
DROP TABLE IF EXISTS `vwpatientwithdoctorscut_csv`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vwpatientwithdoctorscut_csv` AS select `patients`.`radioPatientRptDate` AS `radioPatientRptDate`,`patients`.`radioPatientsName` AS `radioPatientsName`,`patients`.`radioPatientsId` AS `radioPatientsId`,`doctors`.`radioDoctorId` AS `radioDoctorId`,`doctors`.`radioName` AS `radioName`,`cut`.`cut` AS `cut`,`patients`.`radioInvestigation` AS `radioInvestigation`,`patients`.`ass_status` AS `ass_status` from ((`patients` join `cut` on((`patients`.`radioPatientsId` = `cut`.`radioPatientsId`))) join `doctors` on((`cut`.`radioDoctorId` = `doctors`.`radioDoctorId`)));
