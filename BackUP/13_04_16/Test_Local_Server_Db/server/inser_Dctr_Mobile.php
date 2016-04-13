<?php
	include 'config.php';
    // read json file
	$ch = curl_init();
	curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, false);
	curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
	curl_setopt($ch, CURLOPT_URL,'http://192.168.0.105/Test_Local_Server_Db/send_Dctr_Mobile.php');
	$result = curl_exec($ch);
	curl_close($ch);
	$data = json_decode($result, true);
   // $filename = 'http://192.168.0.105/Test_Local_Server_Db/send_Dctr_Mobile.php';
    //$json = file_get_contents($filename);   
    //convert json object to php associative array
    //$data = json_decode($json, true);
    // loop through the array
    foreach ($data as $row) 
	{
        // get the employee details
        $radioDoctorId = $row['radioDoctorId'];
        $radioPhoneMobile = $row['radioPhoneMobile'];
        $alternateMobile1 = $row['alternateMobile1'];
		$alternateMobile2 = $row['alternateMobile2'];   
		$selectDoctId=mysql_query("select radioDoctorId from doctormobilenumber where radioDoctorId='$radioDoctorId'");
		$CountCheck=mysql_num_rows($selectDoctId);
		if($CountCheck > 0)
		{
			
		}
		else
		{
			$insertData=mysql_query("INSERT INTO doctormobilenumber(radioDoctorId, radioPhoneMobile, alternateMobile1, alternateMobile2) VALUES ('$radioDoctorId','$radioPhoneMobile','$alternateMobile1','$alternateMobile2')");
		}
    }  
?>