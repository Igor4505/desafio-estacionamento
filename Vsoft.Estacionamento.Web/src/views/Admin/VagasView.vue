<template>
    <div class="vagas-view">
        <div class="loading" v-if="$store.state.isBusy">
            <img class="carregando" src="@/assets/img/loading_dots.gif"/>
        </div>
        <transition name="modalShow">
            <div class="vagas-view" v-if="!$store.state.isBusy">
                <div class="vagas-view__header">
                    <div style="display: flex; align-items: center">
                        <h1>Vagas</h1>
                    </div>
                    <div class="vagas-view__options">
                        <h2>Disponível: {{disponibilidade.disponiveis}}</h2>
                        <h2>Ocupadas: {{disponibilidade.ocupadas}}</h2>
                    </div>
                </div>
                <div class="vagas-view__content">
                    <!-- VAGAS -->
                    <transition-group name="modalShow">
                        <div class="vagas-view__ilha" v-for="ilha in ilhas" :key="ilha.id">
                            <h2>Ilha {{ ilha.id }}</h2>
                            <!-- Adicionar Vaga -->
                            <div class="vagas-view__vagas">
                                <transition name="modalShow" appear v-for="vaga in ilha.vagas" :key="vaga.id">
                                    <id-vaga :placa="vaga.placaVeiculo || 'Plana não informada'" :tempo="vaga.ocupada ? new Date(vaga.dataEntrada).toLocaleTimeString() : ''"  @onPressed="isOpened = true; vagaSelecionada = vaga" :ocupada="vaga.ocupada"/>
                                </transition>
                                <id-vaga :carregando="adicionandoVaga"  texto="+" @onPressed="adicionarVaga(ilha.id)"/>
                            </div>
                        </div>

                    </transition-group>
                    <!-- Adicionar Seção -->
                    <div class="vagas-view__adicionar">
                        <h1 v-if="ilhas == undefined || !ilhas.length">Nenhuma ilha de veículos cadastrada</h1>
                        <button class="modal-button" @click="addIlhaModal = true;">Adicionar ilha de veículos</button>
                    </div>
                </div>
                
                <id-modal :isOpened="isOpened" @closeModal="isOpened = false; vagaSelecionada = {}" title="Vaga">
                    <div class="car-form">
                        <id-input :readonly="vagaSelecionada.ocupada" placeholder="Veículo" name="Veiculo" v-model="vagaSelecionada.nomeVeiculo"/>
                        <id-input :readonly="vagaSelecionada.ocupada" placeholder="Cor" name="Cor" v-model="vagaSelecionada.corVeiculo"/>
                        <id-input :readonly="vagaSelecionada.ocupada" placeholder="Placa" name="Placa" v-model="vagaSelecionada.placaVeiculo"/>
                    </div>
                    <div class="cliente-form">
                        <id-input :readonly="vagaSelecionada.ocupada" placeholder="Nome do cliente" name="Nome do Cliente" v-model="vagaSelecionada.nomeCliente"/>
                        <id-input :readonly="vagaSelecionada.ocupada" placeholder="CPF do cliente" name="Cpf do Cliente" v-model="vagaSelecionada.cpfCliente"/>
                        <div class="dados-vaga" v-if="vagaSelecionada.ocupada">
                            <div class="dados-vaga__info">
                                <label>Hora de entrada</label>
                                <p>{{new Date(vagaSelecionada.dataEntrada).toLocaleTimeString()}}</p>
                            </div>
                            <div class="dados-vaga__info">
                                <label>Hora de saída</label>
                                <p>{{ horaSaida.toLocaleTimeString() }}</p>
                            </div>
                            <div class="dados-vaga__info">
                                <label>Tempo estacionado</label>
                                <p>{{ tempoEstacionado }}</p>
                            </div>
                        </div>
                        <div class="dados-vaga" v-if="vagaSelecionada.ocupada">
                            <div class="dados-vaga__info">
                                <label>Taxa base</label>
                                <p>R$ 7,00</p>
                            </div>
                            <div class="dados-vaga__info">
                                <label>Horas extras</label>
                                <p>R$ {{ 3 * horasExtras}} ,00</p>
                                <p><small>{{ horasExtras}}h x R$ 3,00</small></p>
                            </div>
                            <div class="dados-vaga__info">
                                <label>Total</label>
                                <p>R$ {{total}},00</p>
                            </div>
                        </div>
                        <br>
                        <button :disabled="editandoVaga" class="modal-button" @click="vagaSelecionada.ocupada ? receberValor() : ocuparVaga()">
                            <img v-if="editandoVaga" class="carregando__botao" src="@/assets/img/loading_dots.gif"/>
                            <span v-else>{{vagaSelecionada.ocupada ? 'Receber Valor' : 'Ocupar Vaga'}}</span>
                        </button>
                    </div>
                </id-modal>
                <id-modal size="small" title="Adicionar Ilha" :isOpened="addIlhaModal" @closeModal="addIlhaModal = false">
                    <div class="car-form" style="text-align: center">
                        <id-input :readonly="adicionandoIlha" name="Localização" v-model="LocalizacaoIlha" placeholder="Localização da ilha" />
                        <br>
                        <span style="color: darkred; margin-top: 20px;" v-if="erroIlha.length">{{ erroIlha }}</span>
                        <button :disabled="adicionandoIlha" style="margin-top: 20px;" class="modal-button" @click="adicionarIlha()">
                            <img v-if="adicionandoIlha" class="carregando__botao" src="@/assets/img/loading_dots.gif"/>
                            <span v-else>Adicionar</span>
                        </button>
                    </div>
                </id-modal>
            </div>
        </transition>
    </div>
</template>

<script>
import IdVaga from '@/components/controls/id-Vaga'
import IdModal from '@/components/layouts/id-Modal'
import IdInput from '@/components/controls/id-Input'
export default {
    created(){
        this.$store.dispatch('carregarIlhas')
            .catch((error) => {
                window.alert(error)
            })
    },
    components: {
        IdVaga,
        IdModal,
        IdInput
    },
    computed: {
        ilhas(){
            return this.$store.state.ilhas;
        },
        horaSaida(){
            return new Date(Date.now())
        },
        tempoEstacionado(){
            let tempo = Math.trunc((this.horaSaida.getTime() - new Date(this.vagaSelecionada.dataEntrada).getTime()) / 1000)

            let horas = Math.trunc(tempo / 3600)
            let minutos = Math.trunc((tempo % 3600) / 60);
            let segundos = Math.trunc(((tempo % 3600) % 60))

            return horas.toString().padStart(2, 0) + ':' + minutos.toString().padStart(2,0) + ':' + segundos.toString().padStart(2,0);
        },
        horasExtras(){
            let tempo = Math.trunc((this.horaSaida.getTime() - new Date(this.vagaSelecionada.dataEntrada).getTime()) / 1000)
            let horas = Math.trunc(tempo / 3600)
            return Math.ceil(horas);
        },
        total(){
            return 7 + (this.horasExtras * 3);
        },
        disponibilidade(){
            let disponiveis = 0;
            let ocupadas = 0;
            this.ilhas.forEach(ilha => {
                if(ilha.vagas != null) {
                    ilha.vagas.forEach(vaga => {
                        vaga.ocupada ? ocupadas += 1 : disponiveis +=1
                    });
                }
            });

            return {
                "ocupadas" : ocupadas,
                "disponiveis": disponiveis
            }
        }
    },
    data() {
        return {
            addIlhaModal: false,
            isOpened: false,
            adicionandoVaga: false,
            adicionandoIlha: false,
            editandoVaga: false,
            LocalizacaoIlha: '',
            erroIlha: '',
            email: '',
            vagaSelecionada: {}
        }
    },
    methods: {
        adicionarIlha() {
            if(!this.LocalizacaoIlha.length){
                this.erroIlha = 'Esse campo é obrigatório'
            }
            else {
                this.erroIlha = '';
                this.adicionandoIlha = true;
                this.$store.dispatch('adicionarIlha', this.LocalizacaoIlha)
                    .then(() => {
                        this.addIlhaModal = false;
                        this.LocalizacaoIlha = '';
                    })
                    .catch((error) => {
                        this.erroIlha = error.message;
                        
                    })
                    .finally(() => {
                        this.adicionandoIlha = false;
                    })
            }
        },
        adicionarVaga(idIlha) {
            if(!this.adicionandoVaga) {
                this.adicionandoVaga = true;
                this.$store.dispatch('adicionarVaga', idIlha)
                    .catch(error => {
                        window.alert(error.message)
                    })
                    .finally(() => {
                        this.adicionandoVaga = false;
                    })
            }
        },
        receberValor(){
            this.editandoVaga = true;
            let payload = {
                'id': this.vagaSelecionada.id,
                'dataSaida': this.horaSaida,
                'valorTotal': this.total,
                'idIlha': this.vagaSelecionada.idIlha
            }
            this.$store.dispatch('receberValor', payload)
                .catch((error) => {
                    window.alert(error.message)
                })
                .finally(() => {
                    this.isOpened = false
                    this.editandoVaga = false;
                })

        },
        ocuparVaga(){
            this.editandoVaga = true;
            this.$store.dispatch('ocuparVaga', this.vagaSelecionada)
                .catch(error => {
                    window.alert(error.message)
                })
                .finally(() => {
                    this.isOpened = false
                    this.editandoVaga = false;
                })
            
        }
    }
}
</script>

<style scoped>
.vagas-view{
    flex: 1;
   overflow-y: auto;
}
.vagas-view__header{
    display: flex;
    align-items: center;
    padding: 32px 32px 10px;
}
.vagas-view__options{
    display: flex;
    align-items: center;
}
.vagas-view__header h1{
    flex: 1;
}

.vagas-view__header h2{
    margin: 0 20px;
}

.vagas-view__options button {
    height: 40px;
    border-radius: 20px;
    border: solid var(--primary-color) 1px;
    background-color: transparent;
    cursor: pointer;
}

.vagas-view__content{
    flex: 1;
}
.vagas-view__vagas{
    display: flex;;
    flex-wrap: wrap;
}

.vagas-view__ilha{
    padding: 16px;
   
}
.vagas-view__ilha h2{
    margin: 0 16px;
    padding-bottom: 16px;
    border-bottom: solid var(--gray-2) 1px;
}


.car-form{
    padding: 25px;
    border-bottom: solid 1px var(--gray-1);
}
.cliente-form{
    text-align: center;
    padding: 25px;
}
.dados-vaga{
    margin: 20px 0 30px;;
    display: flex;
    justify-content: space-around
}
.dados-vaga__info{
    text-align: center;
}
.dados-vaga__info label {
    color: var(--gray-1);
    padding-bottom: 5px;
    display: block;
    font-size: 12px;
    font-weight: var(--black);
}
.modal-button{
    width: 90%;
    height: 40px;
    background: #3E4095;
    border-radius: 20px;
    border: none;
    color:white;
    font-weight: var(--semibold);
}

.gerenciar-vagas{
    min-height: 300px;
    padding: 20px;
    display: flex;
    align-items: stretch;
    flex-direction: column;
}
.adicionar-vagas{
    flex: 1;
}
.adicionar-vagas__header{
    padding-bottom: 15px;
    padding-right: 12px;
    display: flex;
    justify-content: space-between;
}
.lista-ilhas{
    display: flex;
    justify-content: space-between;
    margin-bottom: 15px;
}
.qnt-ilhas{
    display: flex;
    align-items: center;
}

.qnt-ilhas h2{
    margin: 0 10px;
    color: var(--gray-1);
}
.vagas-view__adicionar{
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    align-items: center;
    text-align: center;
}
.vagas-view__adicionar button {
    margin: 30px 0;
    width: 300px;
}
@media (max-width: 767px) {
    .vagas-view__header{
        flex-direction: column;
        align-items: flex-start;
    }
    .vagas-view__header h2{
        margin: 0;
    }
    .vagas-view__options{
        width: 100%;
        justify-content: space-between;
        margin-top: 20px;
    }
    .vagas-view__adicionar button {
        width: 80%;
    }
}
.config-icon{
    display: none;
    margin: 0 10px;
}
@media (max-width: 520px) {
    .vagas-view__header button {
        display: none;
    }
    .config-icon{
        display: block;
    }
   
}
.loading{
    width: 100%;
    height: 80%;
    display: flex;
    align-items: center;
    justify-content: center;
}

button:disabled{
    background-color: lightgray;
    cursor: progress;
}
.carregando__botao{
    width: 40px !important;
}
</style>