<?php 
header("Content-Type: text/html; charset=utf-8"); 
session_start();
if ($_SESSION['send'] == $_SERVER['REMOTE_ADDR'])  
{
$login = $hpassword = $email = $temp = '';
$_SESSION['message'] = ''; 
$flag = true;
if (!empty($_GET["login"])) {
	$login = strip_tags($_GET["login"]);
$login = htmlspecialchars($login);}
else {$flag = false ; $_SESSION['message'] = '������� ������ login!'; }
if (!empty($_GET["password"]))
	{ 	
	$temp = htmlspecialchars($_GET["password"]);
	$temp = strip_tags($temp);
	$hpassword = crypt($temp,'$1$qwe$');
	}
else {$flag = false ; $_SESSION['message'] = '������� ������ password!'; }
if (filter_var($_GET["email"], FILTER_VALIDATE_EMAIL) && !empty($_GET["email"])) {	
    $email = strip_tags($_GET["email"]); 
$email = htmlspecialchars($email);}
else {$flag = false ; $_SESSION['message'] = '������� ������ email!'; }
$mysqli = mysqli_connect("localhost", "root", "", "emails");
if (mysqli_connect_errno()) { 
    $_SESSION['message'] = mysqli_connect_error();
	$flag = false;
}
if($flag == true)
{
	$stmt = mysqli_prepare($mysqli, "INSERT INTO users (login, password, email) VALUES (?, ?, ?)");
	mysqli_stmt_bind_param($stmt, 'sss', $login, $hpassword, $email);
	if (mysqli_stmt_execute($stmt) === TRUE) {
    $_SESSION['message'] = 'Done'; }
    else {
    $_SESSION['message'] = 'error'; 
	}
	mysqli_stmt_close($stmt);
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