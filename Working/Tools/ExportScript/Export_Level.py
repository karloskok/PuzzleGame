bl_info = {
    "name": "Export level",
    "author": "karloskok",
    "version": (1, 0),
    "blender": (2, 75, 0),
    "location": "View3D > Add > Mesh > Export level",
    "description": "Export level",
    "warning": "",
    "wiki_url": "",
    "category": "Add Mesh",
    }

import bpy
import os
   
class HelloWorldPanel(bpy.types.Panel):
    """Creates a Panel in the Tools window"""
    bl_label = "Game Tools"
    bl_idname = "OBJECT_PT_hello"
    bl_space_type = 'VIEW_3D'
    bl_region_type = 'TOOLS'
    bl_category="Tools"

    def draw(self, context):
        layout = self.layout

        obj = context.object
        
        row = layout.row()
        #row.label(text="Hello world!", icon='WORLD_DATA')
        row.label(text="Filename:  " + os.path.basename(bpy.data.filepath))
        row = layout.row()
        row = layout.row()
        row.operator("myops.exportlevel")
        #row.operator("mesh.primitive_cube_add")
        row = layout.row()
        row = layout.row()
        row = layout.row()
        row = layout.row()
        #row.label(text="Active object is:   " + obj.name)
        
        col = layout.column(align=True)
        #row = layout.row()
        col.operator("myops.addmeshcollider", text='Add MeshCollider to active obj', icon='MESH_PLANE')
        #row = layout.row()
        col.operator("myops.addboxcollider", text='Add BoxCollider to active obj', icon='MESH_CUBE')
        #row = layout.row()
        col.operator("myops.addcapsulecollider", text='Add CapsuleCollider to active obj', icon='MESH_CYLINDER')
        row = layout.row()
        row = layout.row()
        row.operator("myops.addarea", text='#Area', icon='LATTICE_DATA')#####
        row = layout.row()
        row = layout.row()
        row.operator("myops.addmove", text='#Moveable', icon='POSE_DATA')#####
        row = layout.row()
        row = layout.row()
        row.operator("myops.addtrigger", text='#Trigger', icon='POSE_DATA')#####
        row = layout.row()
        row = layout.row()
        
        
        #col = layout.column(align=True)
        #col.operator("myops.addmatwall", text='AddmaterialToAllObjects', icon='MESH_CAPSULE')
        #col.operator("myops.addmatwall")
        #col.operator("myops.addmatwall")
        #col.operator("myops.addmatwall")
        
        row = layout.row()
        row = layout.row()                
        row.operator("myops.mattoall", text='Add material to all objects',  icon='MATERIAL_DATA')
        row = layout.row()
        row = layout.row()
        row.operator("myops.removeall", text='Remove tags from name', icon = 'X')
        
#add mat to all objects

def mattoall(context):
    
    if(bpy.data.materials.get("Pallete")):
        mat=bpy.data.materials.get("Pallete")
    
    for ob in bpy.data.objects:
        #ob = bpy.context.object               
        
        if ob.data.materials:
            # assign to 1st material slot
            ob.data.materials[0] = mat  
        else:
            # no slots
            ob.data.materials.append(mat)
            
#material class
            
class AddMatToAll(bpy.types.Operator):
    """Tooltips"""
    bl_idname ="myops.mattoall"
    bl_label="AddMatToAllObjects"
    
    def execute(self, context):
        mattoall(context)
        return{'FINISHED'}
    #testcall
    #bpy.ops.myops.mattoall()   
                

  #ADD TAG AREA
def addArea(context, collision):
    obj = context.object
    if obj:
        #obj.name = obj.name.split("#")[0]
        if ("MeshCollider" not in obj.name):
            obj.name += "#" + collision
        elif ("BoxCollider" not in obj.name):
             obj.name += "#" + collision
        elif ("area" not in obj.name):
             obj.name += "#" + collision     
        elif ("CapsuleCollider" not in obj.name):
             obj.name += "#" + collision
        elif ("trigger" not in obj.name):
             obj.name += "#" + collision
        if (collision in "Remove"):
             obj.name= obj.name.split('#')[0]   
        

def addCollider(context, collision):
    obj = context.object
    if obj:
        obj.name = obj.name.split("#")[0]
        if ("MeshCollider" not in obj.name):
            obj.name += "#" + collision
        elif ("BoxCollider" not in obj.name):
             obj.name += "#" + collision        
        elif ("CapsuleCollider" not in obj.name):
             obj.name += "#" + collision
        if (collision in "Remove"):
             obj.name= obj.name.split('#')[0]   


def addMaterial(context, material):
    obj = context.object
    if obj:
        if("-" in obj.name):
            obj.name = obj.name.split("-")[0]           
            obj.name += "-" + material
        else:
            obj.name += "-" + material


class AddTrigger(bpy.types.Operator):
    """Tooltips"""
    bl_idname="myops.addtrigger"
    bl_label="AddTagTrigger"
    
    def execute(self, context):
        addArea(context, "trigger")
        return{'FINISHED'}
    #testcall
    #bpy.ops.myops.addarea()   
    
class AddMove(bpy.types.Operator):
    """Tooltips"""
    bl_idname="myops.addmove"
    bl_label="AddTagMoveable"
    
    def execute(self, context):
        addArea(context, "moveable")
        return{'FINISHED'}
    #testcall
    #bpy.ops.myops.addarea()     
                      
class AddArea(bpy.types.Operator):
    """Tooltips"""
    bl_idname="myops.addarea"
    bl_label="AddTagArea"
    
    def execute(self, context):
        addArea(context, "area")
        return{'FINISHED'}
    #testcall
    #bpy.ops.myops.addarea()               

class AddMatWood(bpy.types.Operator):
    """Tooltips"""
    bl_idname="myops.addmatwood"
    bl_label="AddMaterialWall"
    
    def execute(self, context):
        addMaterial(context, "wall")
        return{'FINISHED'}
    #testcall
    #bpy.ops.myops.addmatwood()  
            
class AddMatWall(bpy.types.Operator):
    """Tooltips"""
    bl_idname="myops.addmatwall"
    bl_label="AddMaterialWall"
    
    def execute(self, context):
        addMaterial(context, "wall")
        return{'FINISHED'}
    #testcall
    #bpy.ops.myops.addmatwall()                            
               

class RemoveAll(bpy.types.Operator):
    """Tooltips"""
    bl_idname="myops.removeall"
    bl_label="RemoveAll"
    
    def execute(self, context):
        addCollider(context, "Remove")
        return{'FINISHED'}
    #testcall
    #bpy.ops.myops.removeall()
    
#mesh collider
class AddMeshCollider(bpy.types.Operator):
    """Tooltips"""
    bl_idname="myops.addmeshcollider"
    bl_label="AddMeshCollider"
    
    def execute(self, context):
        addCollider(context, "MeshCollider")
        return{'FINISHED'}
    #testcall
    #bpy.ops.myops.addmeshcollider()

#box collider
class AddBoxCollider(bpy.types.Operator):
    """Tooltips"""
    bl_idname="myops.addboxcollider"
    bl_label="AddBoxCollider"
    
    def execute(self, context):
        addCollider(context, "BoxCollider")
        return{'FINISHED'}    
    #testcall
    #bpy.ops.myops.addboxcollider()        

#box collider
class AddCapsuleCollider(bpy.types.Operator):
    """Tooltips"""
    bl_idname="myops.addcapsulecollider"
    bl_label="AddCapsuleCollider"
    
    def execute(self, context):
        addCollider(context, "CapsuleCollider")
        return{'FINISHED'}    
    #testcall
    #bpy.ops.myops.addcapsulecollider()        
  
#
# exports each selected object into its own file

def main(context):
    
    #file_path='C:\\Users\\Public\\Documents\\Unity Projects\\Git\\RollerBall\\Assets\\Levels'


    # export to blend file location
    basedir = os.path.dirname(bpy.data.filepath)    

    if not basedir:
        raise Exception("Blend file is not saved")

    scene = bpy.context.scene
    
    for o in scene.objects:
        o.name = o.name.replace('.', '0')
    
    obj_active = scene.objects.active
    selection = bpy.context.selected_objects

    bpy.ops.object.select_all(action='DESELECT')
    
    projectDir=basedir.split("\\Working")[0]
    levelexportdir= projectDir + '\\Assets\\Levels'
       
    nameandextension=os.path.basename(bpy.data.filepath)
    
    name=os.path.splitext(nameandextension)[0]
    
    fn = os.path.join(levelexportdir, name)
    #fn = os.path.join(basedir, name)
    
    #bpy.ops.wm.save_mainfile()
    #bpy.ops.wm.save_mainfile()
    
    bpy.ops.export_scene.fbx(filepath=fn + ".fbx", version='ASCII6100', 
                            global_scale=100.0, axis_forward='Z', axis_up='Y')
    #bpy.ops.export_scene.fbx(filepath=fn + ".fbx", use_selection=True)

    ## Can be used for multiple formats
    # bpy.ops.export_scene.x3d(filepath=fn + ".x3d", use_selection=True)

class ExportLevel(bpy.types.Operator):
    """Tooltips"""
    bl_idname="myops.exportlevel"
    bl_label="ExportLevel"
    
    def execute(self, context):
        main(context)
        return{'FINISHED'}
    
    #testcall
    #bpy.ops.myops.exportlevel()
#
#split filename and extension
#print(os.path.splitext("path_to_file")[0])

def register():
    bpy.utils.register_class(HelloWorldPanel)
    bpy.utils.register_class(ExportLevel)
    bpy.utils.register_class(AddMeshCollider)
    bpy.utils.register_class(AddBoxCollider)
    bpy.utils.register_class(AddCapsuleCollider)
    bpy.utils.register_class(RemoveAll)
    bpy.utils.register_class(AddMatWall)
    bpy.utils.register_class(AddMatToAll)
    bpy.utils.register_class(AddArea)
    bpy.utils.register_class(AddMove)
    bpy.utils.register_class(AddTrigger)
    



def unregister():
    bpy.utils.unregister_class(HelloWorldPanel)
    bpy.utils.unregister_class(ExportLevel)
    bpy.utils.unregister_class(AddMeshCollider)
    bpy.utils.unregister_class(AddBoxCollider)
    bpy.utils.unregister_class(AddCapsuleCollider)
    bpy.utils.unregister_class(RemoveAll)
    bpy.utils.unregister_class(AddMatWall)
    bpy.utils.unregister_class(AddMatToAll)
    bpy.utils.unregister_class(AddArea)
    bpy.utils.unregister_class(AddMove)
    bpy.utils.unregister_class(AddTrigger)


if __name__ == "__main__":
    register()


#split functions
#split=filepath.split(os.sep)

#os.path.normpath(filepath).split(os.path.sep)

#