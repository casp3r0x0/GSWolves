<?php 
//
$session_id   =   $_GET["session_id"]; 
$status   =	$_GET["s"];
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
		 $sql = "UPDATE status SET client_status='$status' WHERE session_id='$mysession_id'";
         $result = mysqli_query($db,$sql);
      }else {
		  //fail 
		  echo "fail" ;  
      }



?>