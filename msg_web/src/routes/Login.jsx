import React from 'react'
import { useState, useContext } from 'react'
import Logo from '../assets/img_logo.png'
import auth  from '../controller/auth'
import { useNavigate } from 'react-router-dom'
import "../styles/login.css"


const Login = ({setLog}) => {
    const [user, setUser] = useState('')
    const [password, setPassword] = useState('')
    const navigate = useNavigate()  

    const handleUser = (e) => {
        e.preventDefault()
        auth(user, password).then((response) => {
            setLog(response)
            if(response == true){
                navigate('/Home')//Hook, algo interessante, useState, useNavigate, useContext... todos esses que começam com use, são hooks
                //Algo bem interessante, devo me aprofundar mais (dito isso dps de ver um video d 30min: tenho memsmo)
            }
        })
    }
    return (
        <div id="login_div">
                <form className="Login" onSubmit={handleUser}>
                        <img src={Logo} alt="logo"/>
                        <h2>Login</h2>
                        <input type="text" placeholder="Digite seu nome de usuário" value={user} onChange={(e) => setUser(e.target.value)} />
                        <input type="password" placeholder="Digite sua senha" value={password} onChange={(e) => setPassword(e.target.value)} />
                        <button type="submit">Entrar</button>
                </form>
                <a href="#">Você não possui uma conta? <strong>Criar</strong></a>
        </div>
    )
}

export default Login //RAFCE