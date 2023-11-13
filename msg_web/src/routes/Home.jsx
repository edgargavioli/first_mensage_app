import React, { Component } from 'react'
import Logo from '../assets/img_logo.png'
import env_icon from '../assets/seta-direita.png'
import "../styles/home.css"
import { useState } from 'react'
import config from "../../apiConfig.json"
import { useNavigate } from 'react-router-dom'
import { useEffect } from 'react'
import { mensagensController } from '../controller/mensagensController'
import Mensagens from '../components/mensagens'

const Home = () => {
  const navigate = useNavigate()
  const user = JSON.parse(localStorage.getItem('user'));
  const [mensagensCont, setMensagensCont] = useState([])
  const [msg, setMsg] = useState('')

  useEffect(() => {
    if (!user) {
      navigate('/');
    }
  }
  , [user])

  const enviarMSG = (e) => {
    e.preventDefault()
    mensagensController.postMensagens(msg, user.id)
    setMsg('')
  }

  useEffect(() => {
   mensagensController.getMensagens(setMensagensCont)
  }, [mensagensCont])

  return (
    <div id='home'>
      <div id='header'>
        <img src={Logo} alt="Logo" />
        <h1>Home</h1>
      </div>
      <div id='contains_msg'>
        <div id='mensage_is_here'>
          {mensagensCont.map((msg, index) => (
            <Mensagens key={index} msg={msg.msg} idUser={msg.idUser}/>
          ))}
        </div>    
      </div>
        <form onSubmit={enviarMSG}>
          <input 
            type="text" 
            placeholder="Digite sua mensagem"
            value={msg}
            onChange={(e) => setMsg(e.target.value)}
          />
          <button id='buttonForm' type='submit'><img src={env_icon} alt="icone enviar" /></button>
        </form>
    </div>
  )
}

export default Home