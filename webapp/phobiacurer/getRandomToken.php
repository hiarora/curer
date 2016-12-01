<?php
include("ws_common.php");
$wsc= new ws_common();
$today = date('YmdHi');
$startDate = date('YmdHi', strtotime('2012-03-14 09:06:00'));
$range = $today - $startDate;
$token = rand(0, $range);
$wsc->InsertTokenIntoTokenTable($token);
echo $token;
?>