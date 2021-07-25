<?php 
$session_id   =   $_GET["session_id"]; 

include("config.php");
   session_start();
      $mysession_id = mysqli_real_escape_string($db,$session_id);
      
      
      $sql = "SELECT * FROM status WHERE session_id = '$mysession_id'";
      $result = mysqli_query($db,$sql);
      $row = mysqli_fetch_array($result,MYSQLI_ASSOC);
      
      $count = mysqli_num_rows($result);
      // If result matched $mysession_id and $mypassword, table row must be 1 row
		
      if($count == 1) {
         // success
		 //print session 
		     echo $row['client_level']. "#" . $row['last_video_viewed'];
      }else {
		  //fail 
		  echo "fail" ;  
      }



?>