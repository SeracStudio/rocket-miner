# rocket-miner
 
![image--000](https://user-images.githubusercontent.com/72404272/104124842-52b64500-5353-11eb-9684-ecf5478ac1a8.png)

 

 

# Documento de Diseño de Juego 

## GuildMasters’ Heritage 

 

 

 

 

 

 

 

 

 

 

 

 

 

 

 

 

 

 

 

 

## Índice 

 

### - Introducción 

- Concepto de juego 

- Características principales (mecánicas, historia y estilo visual) 

- Género 

- Público objetivo 

- Plataformas 

### - Mecánicas 

- Jugabilidad 

- Multijugador (servidor) 

- Personajes 

      - Chica 

      - Robot 

- Enemigos 

- Ítems 

- Controles 

### - Narrativa 

- Trasfondo 

- Personajes 

      - Chica 

      - Robot 

      - Nomed 

### - Arte 

- Diagrama de flujo 

- Interfaces (de menú principal, tutorial, créditos, menú de juego)  

- Arte 2D 

- Arte 3D 

### - Música 

- Sonido ambiente y música 

- Efectos de sonido 

### - Monetización 

- Equipo humano 

- Modelo de negocio y monetización 

- Hitos del desarrollo 

- Business Model Canvas 

- Futuro 

- Salida oficial 

- Expansiones 

 

 

 

 

### Introducción 

Este es el documento de diseño de GuildMasters’ Heritage. Sirva este documento como principal esclarecedor de todos los elementos principales que conforman el juego y que actúe como presentación del proyecto a personas ajenas al desarrollo del mismo. 

#### 1.1 Concepto de juego 

GuildMasters’ Heritage es un videojuego roguelike cooperativo en línea en el que dos jugadores deberán controlar a cada uno de los personajes, una chica llamada Arcelia y un robot apodado S.O.R.A. Estos personajes tienen un gremio minero que se encarga de explorar yacimientos en busca de tesoros a medida que luchan contra los enemigos que se encuentran. 

#### 1.2 Características principales 

El juego tiene tres pilares fundamentales para su diseño: 

- **Cooperación entre jugadores**: el factor fundamental del juego se basa en la cooperación entre ambos jugadores, en el trabajo en equipo para poder completar los niveles. Por ello, se le ha dado a cada personaje unas características propias que, aun haciéndolos autónomos, requieren del otro jugador para poder completar cualquier sala. 

- **Rejugabilidad**: la rejugabilidad es algo intrínseco a los juegos roguelike y esto es algo que buscamos mantener e incluso reforzar con distintos tipos de enemigos y objetos que no tienen por qué aparecer todos en una misma run. 

- **Partidas frenéticas**: habrá mucho movimiento en las partidas, partiendo desde una base más tranquila en las primeras salas, y aumentando la dificultad, cantidad de enemigos, fuerza de los mismos, etc.; haciendo que los jugadores estén concentrados y tensos (en el buen sentido) durante la partida. 

Otras características que tenemos, pero que son menos relevantes a la hora de plantear el desarrollo son: 

- **Narrativa sencilla**: la historia servirá más como excusa para justificar la temática y el inicio del juego que como una narración profunda. Se hablará de temas como la constante repetición, pero desde un punto de vista simple. También habrá toques humorísticos que harán al juego y a los personajes más simpáticos. 

- **Personajes carismáticos**: se va a hacer que los personajes resulten lo más carismáticos posibles y que, tanto su puesta en escena como su propia personalidad, los hagan destacables y reconocibles. 

- **3D lowpoly**: visualmente el juego va a ser tridimensional con una cámara ortogonal o topdown y con modelos lowpoly. 

#### 1.3 Género 

GuildMasters’ Heritage se podría definir de forma burda como la unión de tres juegos: la forma de cooperación que se usa en A Way Out, la temática de Pokémon Mundo Misterioso y los elementos básicos de The Binding of Isaac. 
![image--001](https://user-images.githubusercontent.com/72404272/104124843-52b64500-5353-11eb-9e21-b7eb0e984e9b.jpg)
![image--002](https://user-images.githubusercontent.com/72404272/104124844-534edb80-5353-11eb-8cde-0ca49b483a43.jpg)
![image--003](https://user-images.githubusercontent.com/72404272/104124841-521dae80-5353-11eb-8c65-3e79cf9b011c.jpg)

*Principales referencias de GuildMasters’ Heritage* 

Los elementos que toma a nivel mecánico son: 

- **Roguelike**: al igual que The Binding of Isaac, la generación de los pisos es aleatoria, para pasar a la siguiente sala será necesario haber acabado con todos los enemigos de la actual, habrá una gran cantidad de objetos que darán la personalización que se quiere. Estos elementos son comunes a los roguelike (como pasa con Hades o el mismo Pokémon Mundo Misterioso) pero se menciona a The Binding of Isaac por ser la punta de lanza del género. 

- **Cooperación**: al igual que en A Way Out, la cooperación entre ambos jugadores es fundamental para poder conseguir pasar el nivel. Se complementan tanto a nivel mecánico como a nivel narrativo y la muerte de uno (en este caso la chica es la única que puede ser derrotada) conlleva la pérdida para ambos. 

#### 1.4 Público Objetivo 

Debido a su planteamiento multijugador cooperativo, el juego está pensado para personas que suelen tener disponible algún amigo o familiar con el que jugar. El tono que va a tener el juego va a hacer que sea simpático, pero no infantil, ya que va a haber ciertas bromas o comentarios que solo un público algo más adulto entienda, pero no impide o dificulta el disfrute a los más pequeños. También, debido a que no va a suponer un cambio radical con respecto al género, los fans de los roguelike también se van a sentir muy cómodos jugando a GuildMasters’ Heritage. Es por esto, que nuestro público preferente son estos aficionados al género de una edad de entre 12 a 16 años, que es donde más se suele jugar con amigos. 

#### 1.5 Plataformas 

La plataforma principal es el navegador. Sin embargo, se va a hacer que sea responsive para que se pueda jugar de igual forma en navegadores de otros dispositivos como móviles o tablets. 

 

### 2. Mecánicas 

En este apartado del documento se explicará la parte jugable del videojuego, desde las stats de los personajes y sus habilidades básicas hasta los objetos y enemigos. Además, se adentrará en la arquitectura que se va a utilizar para el servidor y se describirá como sería una partida típica. 

#### 2.1 Jugabilidad 

Al iniciar una partida, ambos jugadores deberán decidir qué avatar quieren: si la chica, que es más ofensiva y rápida; o el robot, que es más defensivo y resistente. Una vez hayan elegido personaje, iniciará la partida mostrando una cinemática donde, de forma rápida, se haga una puesta en escena de la situación, la historia que hay detrás y ‘la excusa’ para que los personajes tengan que bajar por una mina. Tras la cinemática inicial, comenzará el juego. 

Cada partida de GuildMasters’ Heritage contará con 5 plantas y una sala con el final boss. Cada planta está compuesta por un número aleatorio de salas. Al entrar en cada sala, sólo se podrá salir una vez se hayan derrotado a todos los enemigos que hay en ella o se haya abierto el tesoro (o los tesoros). Para pasar a la siguiente planta, se deberá encontrar unas escaleras, que estarán en una sala aleatoria de la planta, que nos llevará a la sala del jefe de la planta actual. Una vez lo derrotemos bajaremos a la siguiente planta. Para que toda esta disposición esté claro en todo momento, habrá un mapa en la esquina superior para que cada jugador pueda ver lo que lleva descubierto del mapa. Además, hay un objeto que revela el mapa entero de la planta. 

La distribución de una sala será aleatoria, aunque se elegirá entre ‘sala de enemigos’ y ‘sala de tesoros’. 

- **Sala de enemigos**: en estas salas habrá dos elementos: enemigos y rocas, estalagmitas o algún otro elemento similar que sirva como limitante del movimiento. El número de enemigos que haya en cada sala estará aleatorizado, pero siempre con una lógica detrás, es decir, si es un enemigo relativamente débil va a haber más que si es un enemigo poderoso. El orden y posición de las rocas en cada sala será aleatorio también, pero siempre que no corte ningún camino al jugador. Se busca que al jugador le cueste más moverse y si se encierra sea porque un enemigo le corta el paso (esto es igual a decir que es porque el jugador ha guiado al enemigo a que le encierre).  

- **Sala de tesoros**: estas salas pueden ser simplemente un tesoro que encontramos y podemos continuar a otra sala o un cofre cerrado que se abrirá una vez hayamos derrotado a todos los enemigos de la sala. El cofre actuará a modo de limitante de movimiento como ocurre con las rocas, que también estarán presentes en este tipo de sala. 

La dificultad del título irá aumentando según se vaya bajando en las plantas, pero como cada sala tiene el componente de la aleatoriedad puede ser que haya salas más fáciles en plantas más profundas. En la dificultad entra también el tema de los objetos, cuya disposición es aleatoria (aunque se hará que los ítems más poderosos sean más probables de encontrar en las plantas más difíciles), de forma que la progresión del jugador depende en gran medida del factor random, algo normal en los juegos de este género. 

##### 2.1.1 Multijugador 

Como ya se ha dicho en la introducción, la cooperación entre ambos jugadores es vital para completar los niveles. El juego está pensado por y para un gameplay conjunto donde las dos personas que jueguen se ayuden mutuamente para poder superar todas las plantas. Esto se explicará mejor más adelante, en las habilidades de los personajes, los ítems y los enemigos. Sin embargo, ahora se pasará a explicar la arquitectura y cómo se va a hacer el sistema multijugador. 

[GERMÁN AQUÍ ESCRIBES LO DEL SERVIDOR: CÓMO LO HACES Y TAL] 

#### 2.2 Personajes 

En los personajes podemos distinguir entre los personajes protagonistas (la chica y el robot) cuyas historias y elementos narrativos, así como aspecto definido se describirá en el apartado de Narrativa; y los enemigos, que tendrán menos personalidad y son más herramientas mecánicas para poner un desafío al jugador a personajes con cierto trasfondo. Sin embargo, los 5 bosses que hay sí van a tener cierta profundidad y mecánicas propias. 

##### 2.2.1 La chica - Arcelia 

Es la que se podría considerar como la verdadera protagonista del juego e hija de los fundadores del gremio que dirige. A pesar de su corta edad, 11 ó 12 años, ya tiene mucha experiencia en el campo de la exploración y en las minas por lo que se desenvuelve bien en situaciones de riesgo. Tiene una mentalidad positiva y piensa que cada día que exploren una cueva, los tesoros que van a encontrar serán mejores que los de la vez anterior. 

Stats base de la chica: 

- Velocidad de movimiento: 6 

- Velocidad de disparo: 3 balas por segundo 

- Daño de disparo: 2 puntos 

- Salud: 100 

- Cooldown de habilidades: depende de la habilidad. En el caso del disparo su cd dependerá de su velocidad de disparo; la chica cuenta con dos dashes, teniendo el primero un cooldown de 0.75s y al usar el segundo, de 3s.  

Habilidades base de la chica: 

- Disparo: a través de un arma realizará un disparo hacia donde esté mirando el personaje. 

- Dash: tendrá dos pequeños dashes que le permitirá moverse rápidamente a una posición cercana. El cooldown del primer dash será muy pequeño, pero si se gastan los dos, habrá un cooldown significativamente mayor. 

Todos los valores de estas habilidades o de los stats se irán mejorando (o empeorando) a través de los distintos tesoros que hay en el juego. 

2.2.2 El robot - S.O.R.A. 

Es la acompañante de la chica desde sus primeras expediciones. Siempre se comportó de manera correcta cuando estaban sus padres, pero desde que fallecieron, su personalidad cambió. Seguía haciendo caso a la chica, pero cada vez pensaba que era más absurdo seguir con las exploraciones y estar en un ciclo constante de búsqueda y venta. 

Stats base del robot: 

- Velocidad de movimiento: 6 

- Duración del stun: 1s. Si el enemigo tuviera escudo no hay stun. 

- Cooldown de habilidades: depende de la habilidad. En el caso del puñetazo será de 2s mientras que el del escudo será de 1s. 

Habilidades base del robot: 

- Puñetazo: si un enemigo está a una distancia cercana podrá golpearlo y stunearlo durante un tiempo o, si el enemigo lleva un escudo, desarmarle de ese escudo para que la chica pueda dispararle. 

- Escudo: se mantiene presionado el botón y el robot hará una barrera con su cuerpo que protegerá de cualquier ataque. En este estado, el robot no puede moverse. 

Todos los valores de estas habilidades o de los stats se irán mejorando (o empeorando) a través de los distintos tesoros que hay en el juego. 

![image--004](https://user-images.githubusercontent.com/72404272/104124808-0cf97c80-5353-11eb-8f9c-b547e59526b0.jpg)

*Concept arts de Arcelia y S.O.R.A.* 

 

2.3 Enemigos 

Habrá un total de 20 enemigos, 4 nuevos por cada planta, aunque esto no impide que salgan de enemigos de plantas anteriores. A los enemigos de salas se le asigna un valor de peligrosidad que se va a explicar con un ejemplo: 

Si la planta 1 tiene un factor de peligrosidad de entre 4 y 6, los enemigos que aparezcan en una sala (pongamos que el de esa sala es 5) serán, de forma aleatoria, una combinación cuya suma de sus Peligrosidades sea 5 (por ejemplo 3 Arañas y 1 Minero loco). Según se vayan avanzando en la run, el abanico de la sala se hará mayor (de la planta 2 iría de 5 a 8, siguiendo con el ejemplo).   

2.3.1. Araña 

Son arañas que suele haber en las minas. 

- Tipo de ataque: lanza veneno en forma de proyectil. Su disparo se para poniéndose delante. 

- Cadencia de disparo: 2. 

- Vida: 15 

- Daño de ataque: 2 

- Velocidad: 5 

- Peligrosidad: 1 

- Planta: 1 

2.3.2. Robot lanzaláser 

Robots que se rompieron durante expediciones de otros mineros. 

- Tipo de ataque: lanzan un ataque teledirigido a la chica. Su disparo se detiene con la hab del robot. 

- Cadencia de disparo: 1.5.  

- Vida: 40 

- Daño de ataque: 10 

- Velocidad: 2 

- Peligrosidad: 3 

- Planta: 2, 3 y 4 

2.3.3. Minero piquero 

Mineros que se han vuelto locos debido a que se extraviaron hace muchos años 

- Tipo de ataque: van a melee a golpear con un pico. Se detiene cuando se pega el puño. 

- Velocidad de ataque: 2 golpes por segundo.  

- Vida: 25 

- Daño de ataque: 7 

- Velocidad: 6 

- Peligrosidad: 2 

- Planta: 1 y 2 

2.3.4. Escarabajo minero 

Escarabajo pelotero mecanizado que empuja una bomba 

- Tipo de ataque: cuando ven al jugador van hacia él y explotan 4 segundos después de haber comenzado a moverse (se muere al explotar, no suelta vida). Su explosión se detiene con la hab del robot. 

- Radio de explosión: 5 m. 

- Vida: 15 

- Daño de ataque: 15 

- Velocidad: 8 

- Peligrosidad: 2 

- Planta: 2 y 3 

2.3.5. Slime 

Monstruo de slime que se divide cuando se derrota. Se divide de 1 a 2 y de 2 a 4. 

- Tipo de ataque: huye del jugador y cuando es derrotado se divide. 

- Vida: 20, 10 y 10 y 5, 5, 5 y 5. 

- Daño de ataque: 0 

- Velocidad: 4 

- Peligrosidad: 1 

- Planta: todas 

2.3.6. Planta escupidora 

Planta que sale del suelo y lanza veneno desde el óvulo de la planta 

- Tipo de ataque: Está estática y dispara un veneno que te ralentiza. 

- Cadencia de disparo: 1.5. 

- Vida: 30 

- Daño de ataque: 0 

- Velocidad: 0 

- Peligrosidad: 1 

- Planta: todas 

2.3.7. Golem de piedra 

Guerrero de forma humanoide conformado por piedra 

- Tipo de ataque: Camina de forma aleatoria y se detiene para provocar avalanchas del cielo. 

- Enfriamiento habilidad avalancha: 1 vez cada 2 segundos. 

- Número de rocas por ataque: 3 rocas en cada avalancha. 

- Duración de lluvia: Una vez caen las 3 rocas, acaba la habilidad hasta pasar el enfriamiento de la misma. 

- Vida: 60 

- Daño de ataque: 20 

- Velocidad: 6 

- Peligrosidad: 4 

- Planta: 3 y 4 

2.3.8. Topo 

Topo con nariz estrellada y largas garras 

- Tipo de ataque: se mete debajo de tierra y le lanza un zarpazo cuando sale. Si el robot usa su hab en el agujero de salida vuelve al sitio original. 

- Enfriamiento habilidad: Puede crear un agujero a los 2 segundos tras haber usado la habilidad. 

- Vida: 25 

- Daño de ataque: 8 

- Velocidad: 9 

- Peligrosidad: 2 

- Planta: 1 y 2 

2.3.9. Ojo Centinela 

Ojo gigante y morado sobre una columna de piedra 

- Tipo de ataque: Está estático en el centro de la sala y gira 360º disparando un láser continuo. Se para con la hab del robot. Tiene un escudo inicial que hace que los disparos no le quiten vida. El escudo se quita con el puño del robot. 

- Vida: 30 

- Daño de ataque: 8 

- Velocidad: 0 

- Peligrosidad: 4 

- Planta: 2, 3 y 4 

2.3.10. Robot extractor abandonado 

Androide minero con ciertos fallos internos 

- Tipo de ataque: huye de ti y te dispara carbón. Su disparo se para poniéndose delante. 

- Cadencia de disparo: 1.75. 

- Vida: 20 

- Daño de ataque: 10 

- Velocidad: 6 

- Peligrosidad: 2 

- Planta: 1 y 2 

2.3.11. Murciélago 

Murciélago común. 

- Tipo de ataque: se acerca a ti aleteando rápidamente y te muerde. Se detiene usando el puño del robot. 

- Velocidad de ataque: 1 vez por segundo. 

- Vida: 15 

- Daño de ataque: 6 

- Velocidad: 12 

- Peligrosidad: 1 

- Planta: 1 y 2 

2.3.12. Espectro 

Fantasma de mineros fallecidos en su labor en la vida 

- Tipo de ataque: se hace invisible y se acerca al robot para stunearlo. Cuando lo stunea, se hace visible y targeteable 2s y después se vuelve invisible de nuevo. 

- Duración del stuneo: 0.5 seg. 

- Vida: 35 

- Daño de ataque: 0 

- Velocidad: 8 

- Peligrosidad: 1 

- Planta: 1, 2 y 3 

 

##### Comportamiento mejorado:  

2.3.13. Slime de lava 

Monstruo de slime que se divide cuando se derrota. Se divide de 1 a 2 y de 2 a 4. 

- Tipo de ataque: huye del jugador y cuando es derrotado se divide (de 1 a 2 y de 2 a 4) pero si el jugador se acerca le hace daño. 

- Velocidad de ataque: 1 vez cada 2 segundos. 

- Vida: 40, 25 y 25 y 15, 15, 15 y 15 

- Daño de ataque: 5 

- Velocidad: 5 

- Peligrosidad: 2 

- Planta: 4 y 5 

2.3.14. Planta enredadera 

Evolución de la planta original cuyas raíces están por fuera de la tierra. 

- Tipo de ataque: Está estática y dispara un veneno que te quita vida. Si te acercas en un radio determinado, te ralentiza 

- Radio para ralentizar: 2 m. 

- Duración ralentización: 2 seg. 

- Cadencia de disparo: 1.7. 

- Vida: 40 

- Daño de ataque: 15 

- Velocidad: 0 

- Peligrosidad: 3 

- Planta: 4 y 5 

2.3.15. Robot extractor abandonado mejorado 

Androide minero moderno con ciertos fallos internos y que fue dejado en la mina 

- Tipo de ataque: huye de ti y te dispara carbón ardiendo que si impacta hace daño residual por tiempo (15 durante 1s). Su disparo se para poniéndose delante. 

- Cadencia de disparo: 1.5. 

- Vida: 30 

- Daño de ataque: 15 

- Velocidad: 5 

- Peligrosidad: 4 

- Planta: 3, 4 y 5 

2.3.16. Abejorro 

Gran abeja que vive bajo tierra y tiene tonos marrones y las antenas más alargadas a lo común 

- Tipo de ataque: va hacia ti, tiene un escudo y te pica. El escudo se quita con puño. 

- Velocidad de ataque: Pica 1 vez cada 2 segundos. 

- Vida: 30 

- Daño de ataque: 15 

- Velocidad: 8 

- Peligrosidad: 3 

- Planta: 3 y 4 

2.3.17. Escarabajo Rinoceronte Explosivo 

Gran escarabajo rinoceronte que, a dos patas, empuja una gran bomba con el resto de sus patas 

- Tipo de ataque: su dura piel actúa de escudo y va hacia ti y explota a los 2 s (si explota se muere y no sueltan vida). El escudo se quita con puño. Su explosión se detiene con la hab del robot. 

- Radio de explosión: 6 m. 

- Vida: 45 

- Daño de ataque: 25 

- Velocidad: 10 

- Peligrosidad: 4 

- Planta: 4 y 5 

2.3.18. Murciélago Mecanizado 

Subespecie de murciélago que ha adaptado cierta tecnología a raíz de los robots abandonados. 

- Tipo de ataque: su parte mecánica actúa de escudo y va hacia ti a gran velocidad y te muerde. El escudo se quita con puño. Si muerde al robot lo stunea. 

- Duración de stunt: 2 seg. 

- Vida: 35 

- Daño de ataque: 12 

- Velocidad: 20 

- Peligrosidad: 3 

- Planta: 4 y 5 

##### Bosses:  
2.3.19. Araña Gigante 

Araña gigante que habita en las minas 

- Tipo de ataque: invoca arañas genéricas. 

- Cd invocación: Puede invocar arañas cada 7 segundos. 

- Número de arañas: 4 arañas por invocación. 

- Tipo de ataque 2: lanza redes que ralentizan al jugador 

- Vida: 100 

- Daño de ataque: 7 

- Velocidad: 10 

- Planta: 1 

2.3.20. Topo Gigante 

Topo gigante que habita en las minas 

- Tipo de ataque: se acerca a la chica y le lanza un zarpazo 

- Tipo de ataque 2: provoca un terremoto que hace que caigan piedras del techo 

- Vida: 80 

- Daño de ataque: 10 

- Velocidad: 12 

- Planta: 2 

2.3.21. Gusano Gigante 

Gusano gigante de piedras que habita en las minas 

- Tipo de ataque: hace agujeros en el suelo y si te caes es GAME OVER 

- Cd habilidad de agujeros: Agujero se crea cada 5 segundos y desaparece a los 10 segundos. 

- Tipo de ataque 2: lanza piedras que rellenan los agujeros del suelo 

- Vida: 150 

- Daño de ataque: 7 

- Velocidad: 10 

- Planta: 3 

2.3.22. Abeja reina Gigante 

Abeja reina gigante adaptada a las minas 

- Tipo de ataque: lanza abejas como si fueran proyectiles. Se para con la hab del robot. 

- Cadencia de disparo: 1.70. 

- Tipo de ataque 2: aletea rápidamente las alas empujando a ambos. Se para con la hab del robot. 

- Enfriamiento habilidad: 10 segundos tras usarlo. 

- Mecánica: hay dos colmenas a los lados, hay que destruir esas colmenas (puño + disparo) para poder quitar el primer escudo a la abeja. Después con puño quitamos el segundo y ya se puede matar. 

- Vida: 100 

- Daño de ataque: 8 

- Velocidad: 0 

- Planta: 4 

2.3.23. Nomed 

Demonio que vive en el fondo de las minas y custodia grandes tesoros 

- Tipo de ataque: invoca otros enemigos (en base a su peligrosidad) que hay que derrotarlos para poder hacerle daño. La peligrosidad límite va aumentando según baja su vida. Enemigos que invoca: 1, 5, 8, 9, 11, 12, 13, 16, 17 y 18. 

- -Comportamiento: se mueve constantemente de izq a der y viceversa y se puede stunear con el puño del robot. 

- Vida: 200 

- Daño de ataque: 0 

- Velocidad: 10 

- Planta: 5 
![image--006](https://user-images.githubusercontent.com/72404272/104125087-ce64c180-5354-11eb-9c03-39b6152b977a.jpg)



*Concept arts de todos los enemigos incluyendo bosses*

 

#### 2.4 Ítems 

2.4.1. Ítem genérico 1 

- Nombre: Botas de explorador. 

- Descripción: Botas de cuero de color marrón que resultan cómodas. 

- Efecto: aumenta la velocidad del usuario (vel_mov*1.5). 

- Posibles usuarios: la chica y el robot. 

- Lugar predominante: primeras plantas (60% en 1 y 30% en 2, 10% resto). 

2.4.2. Ítem genérico 2 

- Nombre: Revientarrocas. 

- Descripción: artefacto antiguo que dispara aire para destruir rocas a presión. 

- Efecto: reduce la velocidad de disparo (vel_dis*0.75) y aumenta el daño (damage*3). A nivel visual supone un cambio de arma. 

- Posibles usuarios: la chica. 

- Lugar predominante: plantas intermedias (30% en 3 y 25% en 4, 45% en resto). 

2.4.3. Ítem genérico 3 

- Nombre: Tuerca W98. 

- Descripción: arreglo ancestral que se le hacían a los robots exploradores. 

- Efecto: reduce la velocidad de movimiento (vel_mov*0.75) y el cooldown (cooldown*0.75). Y aumenta el tiempo de stun (stun*1.5). A nivel visual el robot cambia su color a tonos marrones. 

- Posibles usuarios: el robot. 

- Lugar predominante: cualquier planta (20% en todas). 

2.4.4. Ítem genérico 4 

- Nombre: Brazalete de unión. 

- Descripción: decorativo emblemático de cualquier minero que representa la hermandad entre ambos. 

- Efecto: si ambos están cerca, el daño (damage * 1.5) y vel de disparo (vel_dis * 2) aumenta. 

- Posibles usuarios: la chica. 

- Lugar predominante: Plantas 3 y 4. 

2.4.5. Ítem genérico 5 

- Nombre: Mazorca de maíz. 

- Descripción: Alimento que ayuda a recuperar energía a los mineros.  

- Efecto: restaura 10 puntos de vida.  

- Posibles usuarios: la chica y el robot.  

- Lugar predominante: todas (hace spawn de forma random al matar enemigos). 

2.4.6. Ítem genérico 6 

- Nombre: Gema de torbernita. 

- Descripción: Gema verdosa con la que se potenciaba las Everguns. 

- Efecto: Aumenta daño (damage * 1.5). 

- Posibles usuarios: la chica. 

- Lugar predominante: 1 y 2. 

2.4.7. Ítem genérico 7 

- Nombre: Guantelete automático 

- Descripción: Guantes mecánicos que funcionan por vapor. 

- Efecto: Aumenta vel de disparo (vel_dis * 1.5). 

- Posibles usuarios: la chica. 

- Lugar predominante: 1 y 2. 

2.4.8. Ítem genérico 8 

- Nombre: Reloj de bolsillo. 

- Descripción: Pequeño reloj que se suele llevar a la mina para no perder la noción del tiempo. 

- Efecto: reduce el cooldown de las habilidades (cooldown * 0.75). 

- Posibles usuarios: la chica y el robot. 

- Lugar predominante: plantas 2 y 3. 

2.4.9. Ítem genérico 9 

- Nombre: Cantimplora abandonada. 

- Descripción: Cantimplora que contiene una bebida que ayuda a estar más activo. 

- Efecto: Aumenta velocidad de movimiento (vel_mov * 1.20) y velocidad de disparo (vel_disp * 1.20). 

- Posibles usuarios: la chica. 

- Lugares predominantes: Cualquier planta (20% en todas). 

2.4.10. Ítem genérico 10 

- Nombre: Refrigeración externa. 

- Descripción: Mecanismo anticuado que se usaba para enfriar máquinas mineras. 

- Efecto: Aumenta duración del stun (stun_time * 1.75). 

- Posibles usuarios: el robot. 

- Lugar predominante: plantas 2, 3 y 4. 

2.4.11. Ítem genérico 11 

- Nombre: Amuleto de la suerte. 

- Descripción: Cuentan las leyendas que este pequeño colgante es capaz de revivir a aquellas personas que han muerto con él puesto. 

- Efecto: Revive al morir. 

- Posibles usuarios: Chica (afecta a ambos). 

- Lugares predominantes: Plantas 4 y 5. 

2.4.12. Ítem genérico 12 

- Nombre: Espejo reflector. 

- Descripción: Espejo blindado con la capacidad de hacer rebotar cualquier proyectil que impacte en su superficie. 

- Efecto: refleja el ataque con el escudo. 

- Posibles usuarios: Robot. 

- Lugares Predominantes: Plantas 3, 4 y 5 

 2.4.13. Ítem genérico 13 

- Nombre: Gran Taladradora de Gwein. 

- Descripción: Arma del maestro minero Gwein usaba para cegar a sus enemigos haciendo grandes agujeros por los que entraba la luz. 

- Efecto: Stun en área. 

- Posibles usuarios: Robot. 

- Lugares predominantes: Plantas 2 y 3. 

2.4.14. Ítem genérico 14 

- Nombre: Evergun 3.0. 

- Descripción: Evergun moderna que usan los mineros de alto rango. Incorpora una actualización para extraer minerales. 

- Efecto: Disparo continuo y puede romper las piedras que se encuentre a su paso. 

- Posibles usuarios: Chica. 

- Lugares predominantes: Plantas 3, 4 y 5. 

2.4.15. Ítem genérico 15 

- Nombre: Evergun zurda. 

- Descripción: Versión poco conocida de la Evergun común que se adaptaba para la mano izquierda. 

- Efecto: Disparos contrarios (dispara uno para un lado y otro para el otro). 

- Posibles usuarios: Chica. 

- Lugares predominantes: Plantas 1 y 2. 

2.4.16. Ítem genérico 16 

- Nombre: Magnetgun. 

- Descripción: Arma usada por los mineros de oriente. Aprovecha un proyectil imantado, para hacer que la munición vuelva tras ser disparada. 

- Efecto: Dispara y el tiro vuelve al jugador. 

- Posibles usuarios: Chica. 

- Lugares predominantes: Plantas 2 y 3. 

2.4.17. Ítem genérico 17 

- Nombre: Telenergía. 

- Descripción: Mecanismo que permite a un robot centrar parte de su energía en una zona en concreto. Este necesita de un tiempo de enfriamiento. 

- Efecto: Al principio de cada sala, pone un escudo. 

- Posibles usuarios: Robot. 

- Lugares predominantes: Plantas 1, 2 y 3. 

2.4.18. Ítem genérico 18 

- Nombre: Treasure Changer. 

- Descripción: Se trata de un tesoro maldito que provoca el cambio del cuerpo del minero que lo toque con cualquier ser a su alrededor. 

- Efecto: Cambia roles. 

- Posibles usuarios: Chica y robot. 

- Lugares predominantes: Cualquier planta (15% en todas). 

2.4.19. Ítem genérico 19 

- Nombre: Oiler dañado. 

- Descripción: Herramienta con la que se rellena el tanque de aceite a un robot. 

- Efecto: El robot suelta aceite que provoca daño residual (constante). 

- Posibles usuarios: Robot. 

- Lugares predominantes: Plantas 1, 2 y 3. 

2.4.20. Ítem genérico 20 

- Nombre: Runas ininteligibles. 

- Descripción: Trozo de piedra donde se encuentran una serie de inscripciones en un idioma desconocido. 

- Efecto: Teletransporta a los dos a una sala aleatorio de la planta. 

- Posibles usuarios: Chica y Robot. 

- Lugares predominantes: Plantas 4 y 5. 

2.4.21. Ítem genérico 21 

- Nombre: Almacenador energético. 

- Descripción: Dispositivo capaz de almacenar energía de los músculos y luego soltarla en un solo golpe (vel_dis * 0.5 y damage * 2). 

- Efecto: Puedes cargar el ataque haciendo más daño. 

- Posibles usuarios: Chica. 

- Lugares predominantes: Plantas 3, 4 y 5. 

2.4.22. Ítem genérico 22 

- Nombre: Restos radioactivos. 

- Descripción: Restos de material radiactivo que puede ayudar a los robots a ser más rápidos. 

- Efecto: Aumenta la velocidad de movimiento del robot (vel_mov * 1.5) y reduce el cd de las habilidades (cooldown * 0.75). 

- Posibles usuarios: Robot. 

- Lugares predominantes: Plantas 3 y 4. 

2.4.23. Ítem genérico 23 

- Nombre: Tornillo suelto. 

- Descripción: Tornillo común. ¿Quizá se le ha caído a alguien? 

- Efecto: una vez se entra en una sala, hay una probabilidad (1 de 6) de que se inviertan los controles de movimiento. 

- Posibles usuarios: el robot. 

- Lugar predominante: 2 y 4 

2.4.24. Ítem genérico 24 

- Nombre: Batería 235. 

- Descripción: pequeño cilindro fluorescente con gran capacidad energética 

- Efecto: se potencian todos tus stats (*1.25) pero te hace daño cada vez que cambies de sala. 

- Posibles usuarios: ambos. 

- Lugar predominante: 3, 4 y 5. 

2.4.25. Ítem genérico 25 

- Nombre: Refuerzo cromado. 

- Descripción: cubierta metálica que se incorpora en maquinaria pesada para aumentar su potencia. 

- Efecto: al usar el puño del robot, se empuja al enemigo hasta otro enemigo o una pared stuneándolo (si choca contra un enemigo stunea a ambos). 

- Posibles usuarios: el robot. 

- Lugares predominantes: 4 y 5 

2.4.26. Ítem genérico 26 

- Nombre: "La maldición de Era" (Libro desgastado). 

- Descripción: Libro de cubierta morada y hojas verdes que cuenta la leyenda de Era. 

- Efecto: Al matar a un enemigo, hay una posibilidad de controlarlo hasta que se muera. 

- Posibles usuarios: Chica y robot. 

- Lugar predominante: Planta 3. 

2.4.27. Ítem genérico 27 

- Nombre: Pedernal potenciador. 

- Descripción: Pequeño mineral oscuro que permite aumentar el tamaño de la zona donde se produce el disparo del arma. 

- Efecto: dispara en cono (en una gran área). 

- Posibles usuarios: Chica. 

- Lugares predominantes: Plantas 3 y 4. 

2.4.28. Ítem genérico 28 

- Nombre: Thermic One. 

- Descripción: Tubo relleno de lava, cuya energía interna se aumenta la fuerza de los robots. Requiere de un tiempo para volver a usarse.  

- Efecto: Mata con el primer puño (no contra jefes).  

- Posibles usuarios: Robot. 

- Lugares predominantes: Plantas 2, 3, 4 y 5. 

2.4.29. Ítem genérico 29 

- Nombre: Collar de Nomed. 

- Descripción: Collar del mismo demonio, y en él albergan distintas maldiciones. 

- Efecto: Te teletransporta al jefe de la planta. 

- Posibles usuarios: Chica y robot. 

- Lugares predominantes: Todas las plantas 

2.4.30. Ítem genérico 30 

- Nombre: Buscarrutas. 

- Descripción: Avanzado hardware que muestra los túneles de una mina. 

- Efecto: revela el mapa. 

- Posibles usuarios: ambos. 

- Lugar predominante: 3 y 4. 

2.4.31. Ítem genérico 31 

- Nombre: Pico dorado del gran Monteg. 

- Descripción: Se dice que es el pico más valioso y con el que se han encontrado los mejores tesoros, pero nadie lo ha visto en uso. 

- Efecto: no hace nada. 

- Posibles usuarios: ambos. 

- Lugar predominante: todos. 

2.4.32. Ítem genérico 32 

- Nombre: Moneda Onis. 

- Descripción: Moneda de bronce en la que por una parte está Nomed y por la otra hay un túnel. Se dice que atrae la suerte. 

- Efecto: aleatoriamente aumenta o disminuye una stat (multiplicándolo por 1.5 o 0.5) cada vez que se entre en una sala. 

- Posibles usuarios: ambos. 

- Lugar predominante: 2, 3 y 4. 

2.4.33. Ítem genérico 33 

- Nombre: Cofreto. 

- Descripción: Gran caja de mármol que permite ascender espiritualmente a los mineros si dan todos sus bienes materiales. 

- Efecto: Cambia aleatoriamente todos los objetos que tengan los personajes una sola vez. 

- Posibles usuarios: Chica y robot. 

- Lugares predominantes: Todas las salas. 

2.4.34. Ítem genérico 34 

- Nombre: Mochila paramédica. 

- Descripción: Mochila que se utiliza para los primeros auxilios. 

- Efecto: Cura vida (5 puntos) al entrar en la sala. 

- Posibles usuarios: Chica. 

- Lugares predominantes: 2 y 3. 

2.4.35. Ítem genérico 35 

- Nombre: Alarma antiderrumbamientos. 

- Descripción: Aparato que brilla en un color rojizo que suena un fuerte pitido en el caso de que ocurra un derrumbamiento. La llevan los mineros en su espalda. 

- Efecto: Atrae a los enemigos cuando activa el puño. 

- Posibles usuarios: Robot. 

- Lugares predominantes: 3, 4 y 5. 

#### 2.5 Controles 

Los controles son muy simples y podemos dividirlos según la plataforma en la que se juegue. En navegadores de ordenador, los controles para moverse son W, A, S y D y para lanzar las habilidades serán ESPACIO y SHIFT. En ESPACIO se pondrá la habilidad ofensiva (el disparo en el caso de la chica y el puñetazo en el caso del robot) y en SHIFT se pondrá la ‘defensiva’ (el dash y el escudo) 

 ![image--008](https://user-images.githubusercontent.com/72404272/104125272-f0ab0f00-5355-11eb-88bd-b94220c8e02a.jpg)

Por otro lado, los controles en los navegadores de móviles y tablets serán un joystick para controlar el movimiento y dos botones para cada una de las habilidades. Los botones se colocarán uno abajo a la izquierda y otro arriba a la derecha, como muestra la imagen de abajo. La habilidad ofensiva estará en el inferior y la defensiva en el superior. 

 ![image--010](https://user-images.githubusercontent.com/72404272/104125271-f0127880-5355-11eb-8377-ccb2dc6f7c95.png)

### 3. Narrativa 

En un mundo donde los gremios de exploradores son los organismos más respetados en la búsqueda de tesoros, minerales y piedras preciosas existe un humilde gremio llamado ‘Crystal GuildMasters’, cuyos miembros son una pareja algo peculiar y los protagonistas de este videojuego: Arcelia y S.O.R.A.  

La primera, una preadolescente entusiasta, heredó el gremio tras un trágico accidente donde sus padres fallecieron, el segundo, un robot huraño, actúa como contrapunto de Arcelia y, a la vez, protector de la misma en la mina. 

Ambos se embarcarán en distintas aventuras a lo largo del amplio mundo en la búsqueda de los mayores tesoros que se puedan encontrar, pero tendrán que tener cuidado ya que estos territorios se encuentran llenos de criaturas peligrosas, rivales sin cuartel y todo tipo de enemigos. 

Para saber más acerca de los personajes principales, véase los documentos: Ficha de personaje Arcelia y Ficha de personaje S.O.R.A. en la carpeta de narrativa. 

En este juego, encarnaremos ambos personajes en una de sus aventuras más peligrosas a la mina, donde intentarán una y otra vez llegar al fondo para poder coger uno de los mayores tesoros, uno que ni siquiera sus padres pudieron alcanzar. 

El enemigo final será una criatura llamada Nomed. Poco se sabe acerca de él, ni siquiera si realmente existe o no, pero la mayoría de los gremios no se atreven si quiera a mencionar su nombre. En los últimos años, ir en su búsqueda se ha convertido en sinónimo de fama y éxito, y encontrar objetos malditos que se le atribuyen a él es lo máximo que se ha sacado de estas exploraciones. 

Para saber más acerca de este personaje, véase el documento Ficha de personaje Nomed en la carpeta de narrativa. 

### 4. Arte 

#### 4.1 Diagrama de flujo 

La siguiente imagen muestra los diferentes menús o pantallas a las que se puede acceder en el juego. Si se acaba la partida, se volvería al menú principal. En el siguiente punto (4.2) se muestra cada una de ellas individualmente. 

 
![image--012](https://user-images.githubusercontent.com/72404272/104125279-ff91c180-5355-11eb-9f02-0d0b82c2e18c.png)
 

#### 4.2 Interfaces 

Esta primera imagen muestra el menú inicial con las siguientes opciones: 

- Jugar: te lleva a la pantalla de Crear partida/Buscar partida 

- Opciones: te permite configurar de cierta manera el juego 

- Controles: se te muestran los controles en los dispositivos disponibles 

- Donaciones: te muestra una pantalla donde se muestran las instrucciones de cómo se puede aportar 

 ![image--013](https://user-images.githubusercontent.com/72404272/104125282-0ae4ed00-5356-11eb-8261-9db120860771.png)

Esta imagen muestra la pantalla de Opciones donde se permite configurar el volumen, el idioma del juego y el brillo de la pantalla. Se accede a través del botón de ‘Opciones’ del menú principal. 

 ![image--014](https://user-images.githubusercontent.com/72404272/104125286-10423780-5356-11eb-824b-d3cf1be76aba.png)

La siguiente imagen muestra los Controles tanto en dispositivos móviles como en PC. Las siglas H. D. significa Habilidad Defensiva y H. O. significa Habilidad Ofensiva. Se accede a través del botón de ‘Controles’ del menú principal. 

 ![image--015](https://user-images.githubusercontent.com/72404272/104125290-146e5500-5356-11eb-9c75-272ff40d09f1.png)

En el menú de Créditos se muestra los desarrolladores del título. Se accede a través del botón de ‘Créditos’ del menú principal. 

 ![image--016](https://user-images.githubusercontent.com/72404272/104125320-3b2c8b80-5356-11eb-91b5-fb02faa85845.png)

La pantalla de Donaciones muestra la información necesaria para poder dar algún beneficio al estudio. Se accede a través del botón de ‘Donaciones’ del menú principal. 

 ![image--017](https://user-images.githubusercontent.com/72404272/104125330-4c759800-5356-11eb-9397-a19e25e8c20a.png)

Se accede a través del botón de ‘Jugar’ del menú principal. En este menú se podrá crear una partida introduciendo un nombre y pulsando ‘Crear Partida’, accediendo así a la siguiente imagen; o entrar en alguna de las salas ya creada y esperando a que se introduzca un segundo miembro. 

 ![image--018](https://user-images.githubusercontent.com/72404272/104125334-50a1b580-5356-11eb-83ab-9de412e8fff9.png)

Una vez se click en el botón de ‘Crear Partida’ se accederá a esta pantalla. Aquí se podrá elegir el personaje con el que se jugará, dejando a la persona que crea la partida que elija el personaje que desee dejando a la persona que se una el personaje faltante. 

 ![image--019](https://user-images.githubusercontent.com/72404272/104125338-54cdd300-5356-11eb-8d80-64d991720e40.png)

Tras elegir el personaje, se creará un código y se mantendrá en espera hasta que se una el compañero. 

 ![image--020](https://user-images.githubusercontent.com/72404272/104125341-5c8d7780-5356-11eb-97d0-c70141970fd1.png)

Si en el menú de jugar se entra en una sala ya creada, se asignará el personaje restante y se comenzará la partida tras confirmar. 

 ![image--021](https://user-images.githubusercontent.com/72404272/104125345-61522b80-5356-11eb-9989-723eafbc60ee.png)

#### 4.3 Arte 2D 

A pesar de ser un juego en 3D, ciertos assets se han hecho en pixel art en 2D. Estos son los sprites de los objetos, que una vez cogidos pasan a formar parte de la interfaz ingame, apareciendo a la derecha de la barra de vida. El resto de interfaz ingame, es decir, la barra de vida, las barras de cooldown y los botones y joystick del modo en móvil también son elementos en 2D que se han hecho por nuestro equipo creativo. 

Por otro lado, la mayoría de los elementos de los menús y la UI previa al juego, esto se refiere a botones, sliders, inpufields, etc; también se han hecho en 2D. Lo único de todos los menús previos que no es bidimensional son los muros de fondo que se ha reutilizado los que hay ingame. 

Para acabar, se han hecho en 2D los concepts de los personajes y enemigos que se han utilizado para el modelo y para las publicaciones en Twitter. 

 

#### 4.4 Arte 3D 

En cuanto al apartado 3D, como ya se ha comentado en el epígrafe anterior, se han hecho todo lo que es jugable. Los personajes que se pueden controlar, los escenarios, los enemigos y los ataques de los mismos. 

Tanto personajes como enemigos tienen animaciones con las que se mueven y atacan, mientras que los escenarios tienen una iluminación local en las antorchas que hay en los propios modelos. El efecto de iluminación es el mismo en todas las antorchas, mientras que las animaciones son personalizadas, cada personaje, como es lógico, tiene una animación propia para moverse y otra para atacar. Para acabar, en el menú principal hay una animación de movimiento de cámara que se utiliza para mover el menú a lo largo de todas las paredes de la mina. 

### 5.0 Música 

#### 5.1 Sonido ambiente y música 

Tanto la música ambiente, como la música de combate han sido cogidas a partir bibliotecas y obras de terceros, pero libres de copyright. En el juego hay 3 canciones: una utilizada en el menú principal a modo de ambientación, otra es una energética usada para las fases de combate y la última es algo más calmada que intenta evocar el sentimiento de exploración y misterio que se tiene cuando se está en la mina. 

#### 5.2 Efectos de sonido 

Los efectos de sonido, al igual que la música, se han sacado de bibliotecas externas libres de uso. Se han utilizado en distintas secciones como a la hora de pulsar un botón, cuando se recibe un golpe, cuando se cura algo de vida, cuando se golpea, cuando se dispara, etc. 

### 6.0 Monetización 

#### 6.1 Costes asociados 

Los costes asociados al desarrollo serían únicamente los sueldos de los trabajadores y las posibles licencias que se adquirieran. Debido a que trabajamos de forma remota, costes indirectos como oficina, luz o internet no son aplicables, por lo que nos quedarían estos costes directos: 

 


| Tipo de sueldo \ Miembro| Pablo | Germán | Alejandro | Enrique | Darío | Dilan |
| -------------  | -------------  | -------------  | -------------  | -------------  | -------------  | -------------  |
| Sueldo Bruto anual(14 pagas)  | 18.000 | 20.000 | 17.000 | 20.000 | 17.500 | 20.700 |
| Sueldo neto mensual | 1.189,71[5] | 1.321,9 [1] | 1.123,62[2] | 1.321,9 [1] | 1.156,67[3] | 1.368,17[4] |
| Sueldo neto hora | 8,61 | 9,56 | 8,13 | 9,56 | 8,37 | 9,9 |

[1] https://es.indeed.com/career/programador-junior/salaries?hl=es 

[2] https://www.google.com/url?sa=t&rct=j&q=&esrc=s&source=web&cd=&cad=rja&uact=8&ved=2ahUKEwix6snYhNPtAhUr5eAKHe3OBU4QFjABegQIBxAC&url=https%3A%2F%2Fwww.glassdoor.es%2FSueldos%2Fconcept-artist-sueldo-SRCH_KO0%2C14.htm&usg=AOvVaw0vEo9m1CJyxZmyIAgt8kMN 

[3] https://www.academyformacion.com/cuanto-gana-un-animador-3d/ 

[4] https://www.glassdoor.es/Sueldos/junior-game-designer-sueldo-SRCH_KO0,20.htm 

[5] https://www.campus-training.info/cuanto-gana-guionista-descubre-sueldo/ 

 

Por lo tanto, a raíz de estos gastos asociados podemos sacar el dinero necesario para que el videojuego sea sostenible durante los dos años de vida útil que se espera que tenga el juego. Calculando el sueldo neto anual y duplicándolo podemos calcular que el dinero mínimo que tenemos que conseguir es 226.400 euros. 

#### 6.2 Modelo de negocio y monetización 

Para conseguir este dinero, se va a optar por seguir un modelo de negocio freemium. La versión inicial del juego, que es la que se va a lanzar para navegadores, actuará a modo de versión gratuita o beta del mismo y se utilizará para fidelizar un público. Tras un periodo de unos meses donde corrijamos errores de balanceo, de servidores y demás que sean detectados tanto por nosotros como por la comunidad, se sacará una versión 1.0 del juego en tiendas digitales como Steam, Epic o Play Store. 

Esta versión 1.0 sería de pago y vendría con los bugs arreglados y nuevo contenido como nuevos ítems, enemigos o jefes. El precio estimado de esta versión sería 8,99 euros, usando como referencia el precio medio de los roguelike en Steam, que es de 10,79$ [1]. Con este precio, y quitando ventas de móviles, a las cuales realmente no se aspira debido a que los juegos de precio fijo en móviles no suelen tener mucho éxito; se necesitaría vender unas 37.000 copias para no tener pérdidas, una cifra que no es exageradamente alta. 

Una vez se lanzara esta versión, las versiones de navegador tendrían un mensaje en el menú principal anunciando su versión completa y, haciendo click en esa opción, llevaría a la página de Steam o de Play Store dependiendo del dispositivo en el que se esté jugando. 

A lo largo de los dos próximos años se sacarían DLCs de pago, como ocurre con The Binding of Isaac, que incluirían nuevo contenido. Se espera que se saquen 4 expansiones, una cada 5 meses aproximadamente. El precio de cada una de estas expansiones variaría en función del público que esté jugando y el contenido que se incluya, pero rondaría entre los 4 y los 7 euros cada expansión. La primera expansión se intentaría patrocinar yendo al evento de PAX WEST 2021 [2] (septiembre 2021) y a la Madrid Games Week (octubre 2021), eventos que proporcionan stands para juegos indies. Además, la PAX se caracteriza por ser uno de los eventos para los juegos indies de más importancia en la industria. 

Una última posibilidad que se había pensado es negociar el incluir el juego en alguno de los servicios de suscripción de videojuegos como son Xbox Game Pass o Apple Arcade. Estos servicios no solo pagan una tarifa estándar por tener el juego en su plataforma (dinero que recibiríamos) sino que además aumentan las ventas de los mismos [3]. La cantidad de dinero que podemos ganar de esta forma es desconocida ya que por contratos de confidencialidad no se sabe el precio para entrar en estos servicios, pero dado a que todas aumentan cada vez más sus usuarios parece un buen lugar para un juego cooperativo como es este. 

Para acabar tenemos pensado que en la versión de navegador salga un pequeño mensaje tras completar una run (o varias, dependiendo de la dificultad que establezcamos), donde se sugiera al jugador que puede donar y comprar nuestro merchandising. Estas donaciones se cerrarían una vez se publicara la versión 1.0 y lo que se sugeriría en ese mensaje es que se compre la versión de pago correspondiente a la plataforma en la que se juegue. 

[1]https://steamspy.com/tag/Rogue-like 

[2] https://west.paxsite.com 

[3] https://www.xataka.com/videojuegos/sorpresa-xbox-game-pass-gente-compra-que-nunca-juegos-que-puede-descubrir-probar-amar-alli 

Cabe explicar el botón de ‘Donaciones’ que hay en el menú principal. Este botón consta de un pequeño texto explicativo que irá cambiando a lo largo del desarrollo de estos dos años de vida útil del título. Inicialmente contiene un mensaje donde se dicen las formas en las que se puede apoyar actualmente el proyecto (a través de donaciones en la página de itch.io y comprando merchandising de la compañía), se darán las instrucciones y se ofrecerá la posibilidad de hacer click en ciertas imágenes para que abran el Twitter de la compañía y su web, pudiendo ver la tienda. 

La compañía, para empezar 2021 y como método de financiación de la empresa, ha abierto una sección para vender complementos con la marca de Serac Studio. Actualmente solo hay camisetas, sudaderas, pin y mascarillas; pero se espera ampliarla paulatinamente durante todo 2021. Se espera que esta tienda valga para fidelizar y establecer la marca Serac Studio en el imaginario colectivo siendo un sistema de marketing. Para comprar, simplemente hay que enviar un mail a la compañía diciendo el producto, la talla y la cantidad. 

 ![image--022](https://user-images.githubusercontent.com/72404272/104135922-24585a00-5393-11eb-93c0-701b92e93d91.jpg)

#### 6.3 Hitos del desarrollo 

A continuación, se pasa a mostrar una tabla con las principales tareas, su fecha de finalización y las personas que se han encargado de completarlas. 

| Tarea | Fecha de inicio | Fecha de fin | Participantes | Terminado |
| -------------  | -------------  | -------------  | -------------  | -------------  | -------------  | -------------  |
| GDD 1 página | 15/12 | 16/12 | Todos | Sí |
| GDD | 16/12 | 13/01 | Todos |
| Apartado Visual  |   |   |   |   |   |
| Fichas de personajes | 18/12 | 22/12 | Pablo | Sí |
| Diseño de personajes 1 | 14/12 | 20/12 | Alejandro | Sí |
| Diseño de personajes 2 | 21/12 | 27/12 | Alejandro | Sí | 
| Diseño de ítems  | 28/12 | 3/01 | Alejandro | Sí |
| Diseño de interfaz | 4/01 | 10/01 | Alejandro | Sí | 
| Modelado de personajes | 15/12 | 29/12 | Darío | Sí | 

Modelado de escenario 

30/12 

5/01 

Darío 

 

Animación de personajes  

6/01 

12/01 

Darío 

 

Diseño y misc. 

 

 

 

 

Brainstorming 

13/12 

21/12 

Pablo y Dilan 

Sí 

Establecer mecánicas 

11/12 

21/12 

Todos 

Sí 

Equilibrar mecánicas 

21/12 

28/12 

Pablo y Dilan 

Sí 

Planteamiento de narrativa 

11/12 

14/12 

Pablo 

Sí 

Beta Testing 

25/12 

12/01 

Pablo, Dilan, Darío y Alejandro 

 

Realización del tráiler 

11/01 

13/01 

Pablo y Dilan 

 

Management de redes sociales 

15/12 

13/01 

Dilan 

 

Programación 

 

 

 

 

Algoritmo de generación de terreno 

17/12 

24/12 

Germán 

Sí 

Componentes de los personajes 

25/12 

29/12 

Enrique 

Sí 

Sistema de objetos 

25/12 

31/12 

Enrique y Germán 

Sí 

Componentes de enemigos 

18/12 

25/12 

Enrique 

 

Interfaz (PC y móvil) 

30/12 

31/12 

Pablo 

Sí 

Cliente – Servidor 

1/01 

7/01 

Germán y Enrique 

Sí 

Corrección de bugs 

08/12 

13/01 

Germán y Enrique 

 

 

#### 6.4 Business Model Canvas 

 

Por último, se pasa a mostrar el Business Model Canvas del videojuego: 

 ![image--023](https://user-images.githubusercontent.com/72404272/104125899-ea1e9680-5359-11eb-98ee-327c2bec5a87.png)

 

### 7.0 Futuro del proyecto 

En este último apartado se hablará en profundidad del futuro del proyecto y cómo pensamos que se va a mantener rentable durante los siguientes dos años. 

#### 7.1 Salida oficial 

El primer lanzamiento del juego será el 13 de enero de 2021, pero esto solo será en navegadores de dispositivos ya sean portátiles, es decir, móviles y tablets; u ordenadores. Sin embargo, este lanzamiento, donde estarían las mecánicas principales en base a las que gira el diseño del proyecto y los primeros enemigos, objetos y bosses; actuaría a modo de beta abierta o lanzamiento anticipado gratuito que nos serviría para conseguir una base de comunidad, tomar nota de los errores que haya (ya sea que notemos nosotros o que nos diga esta misma comunidad) y a modo de ‘aprendizaje’ para la que sería la salida oficial del juego. 

Tras unos meses, aproximadamente 3, donde hayamos podido hacer algo de publicidad al título a través de prensa especializada o de streamers y youtubers, ya que creemos que es un juego que funcionaría bien en directos por su cooperativo; y hayamos podido resolver diferentes bugs, errores de balanceo y añadir nuevo contenido (más variedad de enemigos, objetos y bosses y aleatoriedad de aparición de estos últimos) saldría la versión 1.0 del juego. Esta versión saldría para tiendas digitales como Steam y Play Store, siendo un juego descargable e instalable. De esta manera, podríamos cobrar por su compra (lo mencionado en el apartado anterior) generando así un ingreso seguro por jugarse y no dependiendo de elementos ‘externos al juego’ como son las donaciones o la venta de merchandising de la web. 

#### 7.2 Expansiones 

Tras la salida de la versión de pago del juego, que sería aproximadamente en abril, se tiene pensado sacar 4 expansiones donde se profundice en la historia y, nuevamente se añadan enemigos, bosses y objetos. Estas expansiones se desarrollarían cada 5 o 6 meses cada una, ya que el contenido que se añada cada vez va a ser mayor y no queremos caer en repeticiones o mecánicas similares a las que ya tengamos, por lo que queremos tener tiempo suficiente como para pensar estos nuevos elementos y balancearlos sin uso de betas abiertas o ‘probando con nuestra comunidad’. La primera expansión coincide con 2 eventos importantes de videojuegos como son la PAX y la MGW (Madrid Games Week) en los que intentaríamos estar para publicitar tanto el juego en sí como la primera expansión. 

Para terminar, el último elemento que incluiríamos sería nuevos personajes. La historia da la flexibilidad suficiente como para introducir nuevos personajes y que siga habiendo una coherencia narrativa y visual. Por otro lado, introducir estos personajes a nivel mecánico sería lo más laborioso ya que se debe mantener la línea de la colaboración entre jugadores, pero sin opacar los personajes que ya hay. Por ello, este último elemento es una idea que no se sabe si se va a realizar y que depende mucho de la evolución y progesión del proyecto. 
