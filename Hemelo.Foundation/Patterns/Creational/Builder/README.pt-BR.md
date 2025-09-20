# Padrão Builder

O **Builder** é um padrão de projeto criacional que permite construir objetos complexos passo a passo. O padrão permite que você produza diferentes tipos e representações de um objeto usando o mesmo código de construção.

-----

## Aplicabilidade

Use o padrão Builder nos seguintes cenários:

  * **Para se livrar de um “construtor telescópico”.**
    Quando você tem um construtor com muitos parâmetros opcionais, a criação de objetos se torna inconveniente. Isso leva à criação de múltiplas sobrecargas de construtores, que podem ser difíceis de gerenciar.

    Por exemplo, considere uma classe `Pizza` com muitos ingredientes opcionais:

    ```java
    class Pizza {
        Pizza(int tamanho) { ... }
        Pizza(int tamanho, boolean queijo) { ... }
        Pizza(int tamanho, boolean queijo, boolean pepperoni) { ... }
        // ... e assim por diante
    }
    ```

    O padrão Builder permite que você construa objetos passo a passo, usando apenas os passos que realmente precisa, evitando a necessidade de uma longa lista de parâmetros no construtor.

  * **Para criar diferentes representações de um produto.**
    O padrão é útil quando a construção de várias representações do produto envolve passos semelhantes que diferem apenas nos detalhes. Por exemplo, construir uma casa de pedra versus uma casa de madeira envolve passos similares (construir paredes, adicionar telhado, instalar janelas), mas com materiais e implementações diferentes. A interface base do builder define todos os passos de construção possíveis, e os builders concretos os implementam para representações específicas.

  * **Para construir árvores Composite ou outros objetos complexos.**
    O padrão Builder permite que você construa produtos passo a passo e até mesmo adie alguns passos. Isso é particularmente útil para construir estruturas complexas como uma árvore de objetos, pois você pode chamar os passos de construção recursivamente. Um benefício chave é que o builder não expõe o produto inacabado, impedindo que o cliente acesse um objeto incompleto ou instável.

-----

## Como Implementar

1.  **Defina os Passos Comuns:** Identifique os passos de construção comuns para criar todas as representações de produto disponíveis e declare esses passos em uma **interface base do builder**.

2.  **Crie Builders Concretos:** Para cada representação do produto, crie uma classe de **builder concreto** que implementa a interface do builder.

3.  **Implemente um Método para Obter o Resultado:** Cada builder concreto deve ter um método para buscar o resultado da construção (ex: `getResultado()`). Este método geralmente não está na interface base porque diferentes builders podem criar produtos que não compartilham uma interface comum.

4.  **Crie um Director (Opcional):** Você pode criar uma classe **Director** que encapsula maneiras comuns de construir um produto. O Director trabalha com um objeto builder para executar uma série específica de passos de construção.

5.  **Código Cliente:** O cliente cria um objeto builder e (opcionalmente) um objeto director. O cliente passa o builder para o director. O director então usa o builder para construir o objeto.

6.  **Obtenha o Produto:** O produto final é recuperado do objeto builder. O cliente deve buscar o resultado do builder, especialmente se builders diferentes produzirem tipos diferentes de produtos.

-----

## Prós e Contras

### ✅ Prós

  * Você pode construir objetos **passo a passo**, adiar passos de construção ou executar passos recursivamente.
  * Você pode **reutilizar o mesmo código de construção** ao criar várias representações de produtos.
  * **Princípio da Responsabilidade Única**. Você pode isolar o código de construção complexo da lógica de negócios do produto.

### ❌ Contras

  * A **complexidade geral do código aumenta**, pois o padrão requer a criação de múltiplas novas classes (interface do builder, builders concretos e um director opcional).

-----

## Relações com Outros Padrões

  * **Factory Method, Abstract Factory e Prototype:** Muitos projetos começam usando o **Factory Method** (menos complicado) e evoluem para **Abstract Factory**, **Prototype** ou **Builder** à medida que se tornam mais complexos.

  * **Abstract Factory:** O padrão Builder foca na construção de objetos complexos passo a passo, enquanto o **Abstract Factory** se especializa em criar famílias de objetos relacionados e retorna o produto imediatamente.

  * **Composite:** Você pode usar o padrão Builder para construir árvores **Composite** complexas, pois pode programar seus passos de construção para funcionar recursivamente.

  * **Bridge:** Você pode combinar o Builder com o padrão **Bridge**. Nesse caso, a classe director desempenha o papel da abstração, enquanto os diferentes builders atuam como implementações.