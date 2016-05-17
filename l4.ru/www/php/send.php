<?php 
header("Content-Type: text/html; charset=utf-8"); 
session_start();
if ($_SESSION['send'] == $_SERVER['REMOTE_ADDR'])  
{
$login = $password = $email = $temp = '';
$_SESSION['message'] = ''; 
$flag = true;
if (!empty($_GET["login"])) {
	$login = strip_tags($_GET["login"]);
$login = htmlspecialchars($login);}
else {$flag = false ; $_SESSION['message'] = 'Неверно указан login!'; }
if (!empty($_GET["password"]))
	{ 	
	$temp = htmlspecialchars($_GET["password"]);
	$temp = strip_tags($temp);
	$password = crypt($temp,'$1$qwe$');
	}
else {$flag = false ; $_SESSION['message'] = 'Неверно указан password!'; }
if (filter_var($_GET["email"], FILTER_VALIDATE_EMAIL) && !empty($_GET["email"])) {	
    $email = strip_tags($_GET["email"]); 
$email = htmlspecialchars($email);}
else {$flag = false ; $_SESSION['message'] = 'Неверно указан email!'; }
$mysqli = mysqli_connect("localhost", "root", "", "emails");
if (mysqli_connect_errno()) { 
    $_SESSION['message'] = mysqli_connect_error();
	$flag = false;
}
if($flag == true)
{
  if (mysqli_query($mysqli, "INSERT INTO users (login, password, email) VALUES ('".$login."', '".$password."', '".$email."')") === TRUE) {
  $_SESSION['message'] = 'Done'; }
  else {
 $_SESSION['message'] = 'error'; 
  }
 mysqli_close($mysqli);
}
}
else {$_SESSION['message'] = 'Error';}
$back = $_SERVER['HTTP_REFERER']; 
echo "
<html>
  <head>
   <meta http-equiv='Refresh' content='0; URL=".$_SERVER['HTTP_REFERER']."'>
  </head>
</html>";
?>