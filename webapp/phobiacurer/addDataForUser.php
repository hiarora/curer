<?php
include("ws_common.php");
$wsc= new ws_common();
error_reporting(0);
if(isset($_GET['token']))	$token = trim($_GET['token']);
else							$token = "";
if(isset($_GET['rating']))	$rating = trim($_GET['rating']);
else							$rating = "";
if(isset($_GET['level']))	$level = trim($_GET['level']);
else							$level = "";

$wsc->AddTrackingDataToUserData($token, $level, $rating);
 ?>
