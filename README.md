# O Caça Palavras

"O Caça Palavras" é um jogo mobile arcade-shooter. O jogador controla uma nave espacial via Joystick e seu objetivo é combater as letras (enemies).

</br>

## Componentes
<p align="center">
<img src="https://user-images.githubusercontent.com/73143716/174647232-b38a5be9-b77e-474c-8a2e-33d5683d4fe7.png" />
</p>

</br>


- Joystick: é responsável por movimentar a nave;
- Botão Verde: é responsável por atirar raios verdes. Os raios verdes capturam a letra (enemy) que for atingida;
- Botão Vermelho: é responsável por atirar balas vermelhas. As balas vermelhas destroem a letra que for atingida;
- Letras: São os inimigos da nave espacial (player), elas spawnam continuamente na parte superior da tela. Se a nave for acertada por uma delas, tomará dano.

</br>
</br>
</br>

As letras capturas são usadas para formar palavras:

<p align="center">
<img src="https://user-images.githubusercontent.com/73143716/174649066-d3269bfd-9bd4-460c-8f3c-04c68d89a8ec.png" />
</p>

- Palavra em azul: Está no caminho certo! Há pelo menos uma palavra que começa com essas letras ("T", "E", "S");
- Palavra em vermelho: Está no caminho errado, não há nenhuma palavra resultante das letras capturadas;
- Palavra em verde: Essa palavra existe! Agora basta segurar pressionado o botão verde para enviar a palavra e ganhar pontos.


</br>
</br>
</br>
</br>

## Sistema de Pontuação
O sistema de pontuação utilizado é similar ao Scrabble.
Diferentes letras tem diferentes probabilidades de spawnarem. Por exemplo, a probabibilidade de spawnar a letra 'A' é de 14/115, já a probabilidade de spawnar a letra 'Z' é de 1/115.

Por consequência, a letra Z será mais valiosa e caso seja incluída numa palavra, somará mais pontos.
Vale ressaltar, também, que o tamanho da palavra impacta no número de pontos.
