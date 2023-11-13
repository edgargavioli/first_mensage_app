import config from "../../apiConfig.json"

const auth = async (user, password) => {
    const url = `${config.url}User/${user}`
    try {
        const response = await fetch(url, {
            method: 'GET',
            headers: {
                'Accept': 'application/json'
            }
        })
        if(response.ok){
            const data = await response.json()
            if (data.senha === password) {
                localStorage.setItem('user', JSON.stringify(data))
                return true
            } else {
                alert("Usuário ou senha inválidos")
                return false
            }
        }
    } catch (error) {
        console.log(error.message)
        return false
    }
}
//OBS: Toda vez que for para esperar uma renspose que faz uma validação de modo "Rapido" usar o async e await, pois os mesmo vão
//fazer com que tudo seja realizado nos seus conformes... (Eu gosto de usar fetch, junto com .then e .catch, mas para esse caso tive que sair
//da zona de conforto e usar o async e await, pois o fetch não estava funcionando como eu queria, e o async e await me ajudaram a resolver o problema :)
export default auth
