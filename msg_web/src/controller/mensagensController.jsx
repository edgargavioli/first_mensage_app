import axios from 'axios'
import React from 'react'

export const mensagensController ={
    getMensagens: async (setMensagenCont) => {
        const response = await axios.get('https://localhost:7254/api/Mensagems')
        setMensagenCont(response.data)
    },
    postMensagens: async (msg, id_user) => {
        const response = await axios.post('https://localhost:7254/api/Mensagems', { 
             msg: msg,
             idUser: parseInt(id_user)
        })
        return response.data
    }
}
