//
//  GameScene.h
//  Rock,Paper,Scissors
//
//  Created by Alec Harrison on 5/21/17.
//  Copyright © 2017 Meráki Studios. All rights reserved.
//

#import <SpriteKit/SpriteKit.h>
#import <GameplayKit/GameplayKit.h>

@interface GameScene : SKScene

@property (nonatomic) NSMutableArray<GKEntity *> *entities;
@property (nonatomic) NSMutableDictionary<NSString*, GKGraph *> *graphs;

@end
