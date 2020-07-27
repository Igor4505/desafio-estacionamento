<template>
    <div class="relatorios">
        <div class="relatorios__opcoes">
            <h1>Relatórios</h1>
            <div style="display: flex">
                <router-link tag="div" class="relatorios__opcao" to="/admin/relatorios" active-class="--btn-active" exact>
                    <id-icon size="50px" color="var(--gray-1)" icon="car"/>
                    <span>Entradas e saídas</span>
                </router-link>
                <router-link tag="div" class="relatorios__opcao" to="/admin/relatorios/financeiro" exact-active-class="--btn-active">
                    <id-icon size="45px" color="var(--gray-1)" icon="money"/>
                    <span>Movimentação financeira</span>
                </router-link>
            </div>
        </div>
        <div class="relatorios__opcoes" style="border-bottom: none;">
            <h1>Entradas e saídas</h1>
            <div class="filtros">
                <input placeholder="Data inicial"/>
                <input placeholder="Data final"/>
                <button>Filtrar</button>
            </div>
            <table>
                <tr>
                    <th style="width: 100px">Vaga</th>
                    <th>Funcionário</th>
                    
                </tr>
                <tr>
                    <td style="width: 100px">A-01</td>
                    <td>Igor Dantas</td>
                   
                </tr>
            </table>
        </div>
    </div>
</template>

<script>
import IdIcon from '@/components/controls/id-Icon'
export default {
    components: {
        IdIcon
    }
}
</script>

<style scoped>
.relatorios{
    padding: 30px;
}
.relatorios * {
    overflow: unset;
}
.relatorios__opcoes{
    padding-bottom: 30px;
    border-bottom: solid var(--gray-2) 1px;
    margin-bottom: 30px;
}
.relatorios__opcoes h1{
    margin-bottom: 20px;
}

.relatorios__opcao{
    width: 120px;
    height: 120px;
    border-radius: 5px;
    box-shadow: 0 0 10px rgba(0,0,0,.3);
    margin-right: 20px;
    background-color: white;
    display: flex;
    align-items: center;
    justify-content: center;
    position: relative;
}
.relatorios__opcao span {
    position: absolute;
    bottom: 5px;
    width: 90px;
    left: calc(50% - 45px);
    text-align: center;
    font-size: 12px;
}

.filtros{
    display: flex;
    justify-content: space-around;
}
.filtros select, input, button{
    width: 22%;
    height: 40px;
    border-radius: 5px;
    border: solid var(--gray-2) 1px;
    padding: 0 10px;
}
.relatorios__opcoes table{
    width: 100%;
    border-spacing: 0;
    margin-top: 20px;
}

.relatorios__opcoes table th {
    color: var(--gray-1);
    font-size: 14px;
    border-bottom: solid var(--gray-1) 1px;
    padding: 15px;
    text-align: left;
}
.relatorios__opcoes table td{
    color: var(--gray-1);
    text-align: left;
    font-size: 14px;
    padding: 15px;
    border-bottom: solid var(--gray-2) 1px;
}
</style>