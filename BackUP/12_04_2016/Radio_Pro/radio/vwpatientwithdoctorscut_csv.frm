TYPE=VIEW
query=select `radio`.`patients`.`radioPatientRptDate` AS `radioPatientRptDate`,`radio`.`patients`.`radioPatientsName` AS `radioPatientsName`,`radio`.`patients`.`radioPatientsId` AS `radioPatientsId`,`radio`.`doctors`.`radioDoctorId` AS `radioDoctorId`,`radio`.`doctors`.`radioName` AS `radioName`,`radio`.`cut`.`cut` AS `cut` from ((`radio`.`patients` join `radio`.`cut` on((`radio`.`patients`.`radioPatientsId` = `radio`.`cut`.`radioPatientsId`))) join `radio`.`doctors` on((`radio`.`cut`.`radioDoctorId` = `radio`.`doctors`.`radioDoctorId`)))
md5=44b2447b50648e1503d7e1ea7ee3ee79
updatable=1
algorithm=0
definer_user=root
definer_host=localhost
suid=2
with_check_option=0
revision=1
timestamp=2016-03-17 12:34:10
create-version=1
source=SELECT patients. radioPatientRptDate, patients. radioPatientsName, patients. radioPatientsId, doctors.radioDoctorId, doctors. radioName, cut.cut FROM patients INNER JOIN cut ON patients. radioPatientsId = cut. radioPatientsId INNER JOIN doctors ON cut. radioDoctorId = doctors. radioDoctorId
