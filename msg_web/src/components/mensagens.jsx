import axios from 'axios';
import React, { useEffect } from 'react'



const mensagens = ({msg, idUser}) => {
    const user = JSON.parse(localStorage.getItem('user'));
    const [nome, setNome] = React.useState('')

    const consulta = async () => {
        if(idUser == localStorage.getItem('user').id){
            setNome(user.nome)
        }else{
            const otherUser = await axios.get(`https://localhost:7254/api/User/GetUserId/${idUser}`)
            console.log(otherUser.data.nome)
            setNome(otherUser.data.nome)
        }
    }

    useEffect(() => {
        consulta()
    }, [idUser])

  return (
    <div className={idUser == localStorage.getItem('user').id ? "me mensagens":"other mensagens"}>
        <p>{nome}:</p>
        <p>{msg}</p>
    </div>
  )
}

export default mensagens