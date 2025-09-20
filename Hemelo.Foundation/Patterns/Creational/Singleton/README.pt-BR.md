# Padrão Singleton

## Aplicabilidade

- Use o **Singleton** quando uma classe deve ter apenas **uma única instância** disponível para todos os clientes.  
  Exemplo: uma conexão de banco de dados compartilhada em diferentes partes de um programa.

- O Singleton desabilita todas as outras formas de criar objetos da classe, exceto através de um **método especial de criação**.  
  - Esse método **cria um novo objeto** ou **retorna o existente**, caso já tenha sido criado.

- Utilize quando for necessário ter **mais controle** sobre variáveis globais.  
  Diferente de variáveis globais, o Singleton garante que:
  - Só exista **uma instância** da classe.  
  - Nada (além da própria classe Singleton) possa substituir a instância em cache.

> 💡 É possível flexibilizar essa limitação e permitir múltiplas instâncias alterando apenas o corpo do método `getInstance`.

---

## Como Implementar

1. Adicione um **campo estático privado** na classe para armazenar a instância única.  
2. Declare um **método estático público** que retorne essa instância.  
3. Implemente a **inicialização preguiçosa (lazy initialization)** nesse método:  
   - Na primeira chamada → cria o objeto e armazena no campo estático.  
   - Nas próximas chamadas → retorna a instância já criada.  
4. Torne o **construtor privado**, impedindo que outros objetos criem instâncias diretamente.  
   - Apenas o método estático da própria classe poderá acessá-lo.  
5. Substitua no código cliente todas as chamadas diretas ao construtor por chamadas ao **método estático de criação**.

---

## Prós

- ✅ Garante que uma classe tenha apenas **uma única instância**.  
- ✅ Fornece um **ponto global de acesso** a essa instância.  
- ✅ Permite **inicialização sob demanda** (objeto criado apenas quando necessário).  

---

## Contras

- ❌ Viola o **Princípio da Responsabilidade Única** (lida tanto com lógica de negócio quanto com controle da instância).  
- ❌ Pode mascarar um **mau design**, criando alto acoplamento entre componentes.  
- ❌ Requer tratamento extra em **ambientes multithread**, para evitar múltiplas instâncias simultâneas.  
- ❌ **Dificulta testes unitários**:  
  - Construtores privados impedem criação de mocks por herança.  
  - Métodos estáticos não podem ser facilmente sobrescritos.  
  - Exige soluções alternativas ou a não utilização do Singleton.

---

## Relação com Outros Padrões

- Uma classe **Facade** pode muitas vezes ser transformada em um **Singleton**, já que em muitos casos um único objeto facade é suficiente.  

- O **Flyweight** se pareceria com o Singleton se todos os estados compartilhados dos objetos fossem reduzidos a apenas um objeto flyweight.  
  No entanto, existem duas diferenças fundamentais:
  1. Deve existir apenas **uma instância Singleton**, enquanto uma classe Flyweight pode ter **múltiplas instâncias** com diferentes estados intrínsecos.  
  2. O **objeto Singleton pode ser mutável**, enquanto objetos Flyweight são **imutáveis**.  

- **Abstract Factories**, **Builders** e **Prototypes** podem todos ser implementados como Singletons.