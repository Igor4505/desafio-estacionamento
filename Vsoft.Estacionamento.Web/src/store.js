import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
    state: {
        isMobile: false,
        ilhas: undefined,
        isBusy: false,
        movimentacoes: undefined
    },
    mutations: {
        setIlha(state, payload) {
            state.ilhas.push(payload)
        },
        setVaga(state, payload) {
            let ilha = state.ilhas.find((ilha) => ilha.id == payload.idIlha)
            
            if(ilha.vagas == null){
                ilha.vagas = [payload]
            }
            else{
                ilha.vagas.push(payload);
            }
        },
        setVagaVazia(state, payload) {
            let ilha = state.ilhas.find(function(ilha) {
                return ilha.id == payload.idIlha
            })
              
            let vaga = ilha.vagas.find(function(vaga) {
                return vaga.id == payload.id
            })
            vaga.corVeiculo = ""
            vaga.cpfCliente = ""
            vaga.dataEntrada = ""
            vaga.dataSaida = ""
            vaga.nomeCliente = ""
            vaga.nomeVeiculo = ""
            vaga.ocupada = false
            vaga.placaVeiculo = ""
            vaga.valorTotal = ""
        },
        setVagaOcupada(state, payload){
            
            let ilha = state.ilhas.find(function(ilha) {
                return ilha.id == payload.idIlha
            })
              
            let vaga = ilha.vagas.find(function(vaga) {
                return vaga.id == payload.id
            })
            console.log(payload)
            vaga = payload;
            vaga.ocupada = true;
        }
    },
    actions: {
        carregarIlhas(context) {
            return new Promise((resolve, reject) => {
                context.state.isBusy = true;
                Vue.prototype.$http.get('ilhas')
                    .then(resp => {
                        context.state.ilhas = resp.data;
                        resolve();
                    })
                    .catch(error => {
                        reject(error);
                    })
                    .finally(() => {
                        context.state.isBusy = false;
                    })
            })
        },
        adicionarIlha(context, payload) {
            return new Promise((resolve, reject) => {
                Vue.prototype.$http.post('ilhas', { 'Localizacao': payload })
                    .then((resp) => {
                        context.commit('setIlha', resp.data);
                        resolve();
                    })
                    .catch((error) => {
                        reject(error)
                    })
            })
        },
        adicionarVaga(context, payload) {
            return new Promise((resolve, reject) => {
                Vue.prototype.$http.post('vagas', { 'IdIlha' : payload })
                    .then((resp) => {
                        context.commit('setVaga', resp.data)
                        resolve();
                    })
                    .catch((error) => {
                        reject(error)
                    })
            })
        },
        ocuparVaga(context, payload) {
            return new Promise((resolve, reject) => {
                Vue.prototype.$http.put('vagas/ocupar', payload)
                    .then((resp) => {
                        let data = new Date(resp.data);
                        payload.dataEntrada = data;
                        context.commit('setVagaOcupada', payload);
                        resolve();
                    })
                    .catch((error) => {
                        reject(error)
                    })
            })
        },
        receberValor(context, payload) {
            return new Promise((resolve, reject) => {
                Vue.prototype.$http.put('vagas/receber', payload)
                    .then(() => {
                        context.commit('setVagaVazia', payload);
                        resolve();
                    })
                    .catch((error) => {
                        reject(error)
                    })
            })
        },
        carregarMovimentacoes(context) {
            return new Promise((resolve, reject) => {
                context.state.isBusy = true;
                Vue.prototype.$http.get('movimentacoes')
                    .then((resp) => {
                        context.state.movimentacoes = resp.data;
                        resolve();
                    })
                    .catch((error) => {
                        reject(error);
                    })
                    .finally(() => {
                        context.isBusy = false;
                    })
            })
        }
    }
})
