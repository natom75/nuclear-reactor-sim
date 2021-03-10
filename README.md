# Simulated Interacive Nuclear Reactor
## TL:DR
This is a simulaton of a standard RBMK (which is graphite-moderated, water cooled) nuclear fission reactor.

## Parameters
- Type of fuel rods: Pure uranium dioxide or uranium oxide with europium oxide (correlates with the number of fissions each second)
- Spentness of the fuel rods: 0-100% (correlates with the number of fissions each second)
- Enrichment of the fuel rods: 1-20%, ideal is 2% (correlates with the number of fissions each second)
- Percent of graphite rods in the reactors' core: (correlates with the number of fissions each second)
- Number of fissions each second: (correlates with the reactors' temperature)
- Reactors' temperature: (correlates with the circulating waters' temperature)
- Circulating waters' speed: (correlates with the reactors' temperature, the circulating waters' temperature and the final heat output)
- Circulating waters' temperature: (correlates with the reactors' temperature and the final heat output)
- Final heat output: (correlates with the circulating waters' temperature)
- Power output: (correlates with the final heat output)

## Interface
The screen consists of a *data page* and a *control page*. The data page consists of 3 sub-pages. In the *reactors' data page* You can see:
- The reactors' **temperature**
- The control rods' status (**percent of the rods in the reactor**)
- The **spentness** of the fuel rods

After that, in the *cooling systems' data page* You can see:
- The circulating waters' **temperature**
- The circulating waters' **speed**

And finally, in the *output page* You can see:
- The final **heat** output
- The **power** output

In the *control page*, You can change the following parameters:
- **The control rods' status per rod**
- **The circulating waters' speed**

But before You start the simulation, You can set the following parameters too. These parameters cannot be changed by You after the simulation has started, but the simulation can affect them, and they affect the simulation too.
- **Type of fuel rods**
- **Enrichment of fuel rods**

## Consequences
It can work or it can blow up.

## How does it work
I don't know it yet
