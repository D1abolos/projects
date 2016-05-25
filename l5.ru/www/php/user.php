<?php 

class user
{
	var $login ;
	var $password;
	var $email;
	var $patternpswd="(?=^.{8,}$)(?=.*[A-Z])(?=.*[a-z]).*";
	var $patternemail="\S+@[A-Za-z]+.[a-z]+";
	var $Con;
	
	/* function __construct($l1, $p1, $e1)	{		
		if (!filter_var($_GET["email"], FILTER_VALIDATE_EMAIL)) 
		throw new Exception("error");	
		if(!preg_match($patternpswd, $password) || !preg_match($patternemail, $email))
		throw new Exception("format error");
		$login = $l1;
		$temp = htmlspecialchars($e1);
		$temp = strip_tags($temp);
		$password = crypt($temp,'$1$qwe$');
		$password = $temp;
		$email = $e1;		 
	}	*/
	public function ConnectToDB() {
		$this->Con = new mysqli("localhost", "root", "", "emails");
		if (mysqli_connect_errno()) {
			$conerr = "connect error " . mysqli_connect_error();
		}
		else {
			$conerr = "";
		}
		return $conerr;
	}
		
	public function Insrt($l1, $p1, $e1) { 
		$this->login = $l1;
		$this->password = $p1;
		$this->email = $e1;

		$querry = $this->Con->prepare("INSERT INTO users (login, password, email) VALUES (?, ?, ?)");
		$querry->bind_param("sss", $this->login, $this->password, $this->email); 
		$querry->execute(); 
		$querry->close();
	}
	public function SelectAll() { 
		$querry = $this->Con->query("SELECT * FROM users");
		return $querry;
	}
	
	public function DeleteAll() { 
		$querry = $this->Con->query("DELETE FROM users");
	}
	
	public function SetPswd($l1, $p1, $e1) { 
		$this->login = $l1;
		$this->password = $p1;
		$this->email = $e1;

		$querry = $this->Con->prepare("UPDATE users SET password=? WHERE email=? AND login=?");
		$querry->bind_param("sss", $this->password, $this->email, $this->login);
		$querry->execute(); 
		$querry->close();
	}
	public function Disconnect() {
		$this->Con->close();
	}
}
?>