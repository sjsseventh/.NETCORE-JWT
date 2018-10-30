<template>
    <div class="page-container">
      <md-app style="min-height: 100vh;">
        <md-app-toolbar class="md-primary" md-elevation="0">
          <md-button class="md-icon-button" @click="toggleMenu" v-if="!menuVisible">
            <md-icon>menu</md-icon>
          </md-button>
          <span class="md-title">WEBAPI Front VueJs</span>
        </md-app-toolbar>

        <md-app-drawer :md-active.sync="menuVisible" md-persistent="mini">
          <md-toolbar class="md-transparent" md-elevation="0">
            <span>Página Inicial</span>

            <div class="md-toolbar-section-end">
              <md-button class="md-icon-button md-dense" @click="toggleMenu">
                <md-icon>keyboard_arrow_left</md-icon>
              </md-button>
            </div>
          </md-toolbar>

        </md-app-drawer>

        <md-app-content>
          <md-table v-model="users" md-card>
            <md-table-toolbar>
              <h1 class="md-title">Produtos</h1>
            </md-table-toolbar>

            <md-table-row slot="md-table-row" slot-scope="{ item }">
              <md-table-cell md-label="ID" md-numeric>{{ item.id }}</md-table-cell>
              <md-table-cell md-label="Nome" md-sort-by="name">{{ item.name }}</md-table-cell>
              <md-table-cell md-label="Valor" md-sort-by="email">{{ item.email }}</md-table-cell>
              <md-table-cell md-label="Data" md-sort-by="gender">{{ item.gender }}</md-table-cell>
            </md-table-row>
          </md-table>

          <md-speed-dial class="md-bottom-right" md-direction="top" md-event="click">
            <md-speed-dial-target class="md-primary">
              <md-icon class="md-morph-initial">view_module</md-icon>
              <md-icon class="md-morph-final">close</md-icon>
            </md-speed-dial-target>

            <md-speed-dial-content>
              <md-button class="md-icon-button md-primary md-raised"  @click="showDialog = true">
                <md-icon>add</md-icon>
              </md-button>
            </md-speed-dial-content>

          </md-speed-dial>

          <md-dialog :md-active.sync="showDialog">
            <md-dialog-title>Cadastro de Produtos</md-dialog-title>
            <md-dialog-content>
              <form novalidate class="md-layout" @submit.prevent="validarProduto">
                <md-field :class="getValidacaoClasse('nome')">
                  <label for="nome">Nome</label>
                  <md-input v-model="form.nome" name="nome" id="nome" :disabled="sending"/>
                  <span class="md-error" v-if="!$v.form.nome.required">O nome é requerido!</span>
                  <span class="md-error" v-else-if="!$v.form.nome.minlength">Nome inválido!</span>
                </md-field>

                <md-field :class="getValidacaoClasse('valor')">
                  <label for="valor">Valor</label>
                  <span class="md-prefix">$</span>
                  <md-input v-model="form.valor" id="valor" type="number" :disabled="sending"></md-input>
                </md-field>

                <md-datepicker v-model="form.data">
                  <label for="data">Data</label>
                </md-datepicker>
              </form>
            </md-dialog-content>
            <md-dialog-actions>
              <md-button class="md-primary md-raised" @click="showDialog = false">Voltar</md-button>
              <md-button class="md-primary md-raised" v-on:click="greet">Salvar</md-button>
            </md-dialog-actions>
          </md-dialog>

        </md-app-content>
      </md-app>
    </div>
</template>

<script>
import { validationMixin } from 'vuelidate'
import { required, minLength } from 'vuelidate/lib/validators'

export default {
  name: 'Menu',
  mixins: [validationMixin],
  data () {
    return {
      form: {
        id: null,
        nome: null,
        valor: 0,
        data: null
      },
      menuVisible: false,
      showDialog: false,
      sending: false,
      users: []
    }
  },
  validations: {
    form: {
      nome: {
        required,
        minLength: minLength(3)
      },
      valor: {
        required
      },
      data: {
        required
      }
    }
  },
  components: {
  },
  methods: {
    toggleMenu () {
      this.menuVisible = !this.menuVisible
    },
    getValidacaoClasse (fieldName) {
      const field = this.$v.form[fieldName]

      if (field) {
        return {
          'md-invalid': field.$invalid && field.$dirty
        }
      }
    },
    limparFormulario () {
      this.$v.$reset()
      this.form.nome = null
      this.form.valor = 0
      this.form.data = null
    },
    salvarProduto () {
      this.sending = true
    },
    validarProduto () {
      this.$v.$touch()

      if (!this.$v.$invalid) {
        this.saveUser()
      }
    },
    greet () {
      this.sending = true
      console.log('teste')
      this.sending = false
    }
  }
}
</script>

<style scoped>
  .md-progress-bar {
    position: absolute;
    top: 0;
    right: 0;
    left: 0;
  }
</style>
