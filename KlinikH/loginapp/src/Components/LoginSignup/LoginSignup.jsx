import React, { useState } from "react";
import "./LoginSignup.css";
import { MdEmail, MdLock, MdPerson } from "react-icons/md";

const LoginSignup = () => {
  const [action, setAction] = useState("Register");

  return (
    <div className="login_container">
      <div className="login_header">
        <div className="login_text">{action}</div>
        <div className="login_underline"></div>
      </div>
      <div className="login_inputs">
        {action === "Login" ? (
          <div></div>
        ) : (
          <div className="login_input">
            <MdPerson className="login_person_icon" size={40} />
            <input type="text" placeholder="Name" />
          </div>
        )}

        <div className="login_input">
          <MdEmail className="login_email_icon" size={40} />
          <input type="email" placeholder="Email" />
        </div>
        <div className="login_input">
          <MdLock className="login_email_icon" size={40} />
          <input type="password" placeholder="Password" />
        </div>
      </div>
      {action === "Register" ? (
        <div></div>
      ) : (
        <div className="login_forgot-password">
          Lost Password? <span>Click Here!</span>
        </div>
      )}

      <div className="login_submit-container">
        <div
          className={action === "Login" ? "login_submit login_gray" : "login_submit"}
          onClick={() => {
            setAction("Register");
          }}
        >
          Register
        </div>
        <div
          className={action === "Register" ? "login_submit login_gray" : "login_submit"}
          onClick={() => {
            setAction("Login");
          }}
        >
          Login
        </div>
      </div>
    </div>
  );
};

export default LoginSignup;
